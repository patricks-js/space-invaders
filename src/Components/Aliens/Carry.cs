using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components.Aliens;

public class Carry : AlienBase, IShootable
{
    private Vector2 _position;
    private Rectangle _bounds;
    private Bullet _bullet;
    private Texture2D _bulletTexture;
    private double _timeToShot;

    public override Texture2D Texture { get; set; }
    public override bool IsAlive { get; set; } = true;
    public override int Points { get; set; } = 40;
    public override Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    public override Rectangle Bounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    public Carry(Vector2 position)
    {
        _position = position;
        _sprites = new Rectangle[SPRITE_FRAMES.ALIENS];
        _timeToShot = RandomManager.Random.Next(1, 10) * 10 / 2;
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Carry");
        _bulletTexture = content.Load<Texture2D>("Sprites/AlienBullet");

        var w = SPRITE_SIZE.ALIENS["width"];
        var h = SPRITE_SIZE.ALIENS["height"];

        _sprites[0] = new(0, 0, w, h);
        _sprites[1] = new(w, 0, w, h);
    }

    public override void Update(GameTime gameTime)
    {
        _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        _timeToShot -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        var x = (int)_position.X;
        var y = (int)_position.Y;
        var w = _sprites[_spriteIdx].Width;
        var h = _sprites[_spriteIdx].Height;

        Animation();

        _bounds = new(x, y, w, h);

        if (_timeToShot <= 0)
        {
            Shoot();
            _timeToShot = RandomManager.Random.Next(2, 6) * 10;
        }

        if (_bullet != null && _bullet.IsOffScreen())
        {
            BulletManager.RemoveBullet(_bullet);
            _bullet = null;
        }

        CheckCollision();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, _position, _sprites[_spriteIdx], Color.White);
    }

    public override void HandleCollision()
    {
        IsAlive = false;
        ScoreManager.Increment(Points);
        EntityManager.RemoveEntity(this);
    }

    public void Shoot()
    {
        var bulletPos = new Vector2(
            Position.X + (_sprites[_spriteIdx].Width - _bulletTexture.Width) / 2,
            Position.Y
        );

        _bullet = BulletManager.CreateBullet(bulletPos, _bulletTexture, Vector2.UnitY, 350f);
    }

    public void CheckCollision()
    {
        foreach (var e in EntityManager.Entities)
        {
            if (_bullet != null && _bullet._bounds.Intersects(e.Bounds) && e is not AlienBase)
            {
                e.HandleCollision();
                BulletManager.RemoveBullet(_bullet);
                _bullet = null;
            }
        }
    }
}
