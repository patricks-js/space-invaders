using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Screens;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Spaceship : EntityBase, IShootable
{
    private Texture2D Texture { get; set; }
    private Vector2 Position { get; set; }
    public override Rectangle Bounds { get; set; }
    private Bullet _bullet;
    private Texture2D _bulletTexture;
    private const int Speed = 5;
    private SpaceInvadersGame _game;

    public Spaceship(Vector2 initialPosition, SpaceInvadersGame game)
    {
        Position = initialPosition;
        _game = game;
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Spaceship");
        _bulletTexture = content.Load<Texture2D>("Sprites/Bullet");
    }

    public override void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Space) && _bullet == null)
        {
            Shoot();
        }

        if (_bullet != null && _bullet.IsOffScreen())
        {
            BulletManager.RemoveBullet(_bullet);
            _bullet = null;
        }

        Bounds = new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        CheckBulletCollision();
        CheckSpaceshipHealth();
        CheckScoreToIncreaseHealth();
        Movement();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }

    public override void HandleCollision()
    {
        SoundManager.PlaySoundEffect("playerexplosion");
        SpaceshipHealthManager.DecreaseHealth();
    }

    public void CheckBulletCollision()
    {
        foreach (var e in EntityManager.Entities)
        {
            if (_bullet != null && _bullet._bounds.Intersects(e.Bounds) && e != this)
            {
                e.HandleCollision();
                BulletManager.RemoveBullet(_bullet);
                _bullet = null;
            }
        }
    }

    private void CheckSpaceshipHealth()
    {
        if (SpaceshipHealthManager.Health <= 0)
        {
            EntityManager.RemoveEntity(this);
            Thread.Sleep(500);
            _game.ChangeScreen(new GameOverScreen(_game));
        }
    }

    private void CheckScoreToIncreaseHealth()
    {
        if (ScoreManager.Score % 1000 == 0)
        {
            SpaceshipHealthManager.IncreaseHealth();
        }
    }

    public void Shoot()
    {
        SoundManager.PlaySoundEffect("shoot");

        var bulletPos = new Vector2(
            Position.X + (Texture.Width - _bulletTexture.Width) / 2,
            Position.Y
        );

        _bullet = BulletManager.CreateBullet(bulletPos, _bulletTexture, -Vector2.UnitY, 500f);
    }

    private void Movement()
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
        {
            if (Position.X >= Margin.X["max"])
            {
                Position = new(Position.X - Speed, Position.Y);
            }
        }

        if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
        {
            if (Position.X < Screen.Width - Margin.X["max"] - Texture.Width)
            {
                Position = new(Position.X + Speed, Position.Y);
            }
        }
    }
}
