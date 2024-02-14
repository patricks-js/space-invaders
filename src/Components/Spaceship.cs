using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Spaceship : IEntity, IShootable
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Bounds { get; set; }
    private readonly List<Bullet> _bullets = new();
    private Texture2D _bulletTexture;
    private const int _speed = 5;

    public Spaceship(Vector2 initialPosition)
    {
        Position = initialPosition;
    }

    public void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Spaceship");
        _bulletTexture = content.Load<Texture2D>("Sprites/Bullet");
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Space) && _bullets.Count == 0)
        {
            Shoot();
        }

        for (int i = _bullets.Count - 1; i >= 0; i--)
        {
            var bullet = _bullets[i];
            bullet.GoUp(gameTime);

            if (bullet.IsOffScreen())
                _bullets.Remove(bullet);
        }

        Bounds = new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        Movement();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);

        foreach (var bullet in _bullets)
        {
            bullet.Draw(spriteBatch);
        }
    }

    public void Shoot()
    {
        SoundManager.PlaySoundEffect("shoot");

        var bulletPos = new Vector2(
            Position.X + (Texture.Width - _bulletTexture.Width) / 2,
            Position.Y
        );

        _bullets.Add(new Bullet(bulletPos, _bulletTexture));
    }

    private void Movement()
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
        {
            if (Position.X >= MARGIN.X["max"])
            {
                Position = new(Position.X - _speed, Position.Y);
            }
        }

        if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
        {
            if (Position.X < SCREEN.WIDTH - MARGIN.X["max"] - Texture.Width)
            {
                Position = new(Position.X + _speed, Position.Y);
            }
        }
    }
}
