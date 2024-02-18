using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class BonusShip : AlienBase
{
    private Vector2 _position;
    private Vector2 _initialPosition;
    private Rectangle _bounds;

    public bool OnScreen { get; set; } = false;
    public float Speed { get; set; } = 100f;
    public double TimeToEnter { get; set; }
    public override bool IsAlive { get; set; } = true;
    public override Texture2D Texture { get; set; }
    public override int Points { get; set; }
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

    public BonusShip()
    {
        TimeToEnter = RandomManager.GetRandomTime();
        Points = RandomManager.GetRandomPoints();

        _initialPosition = new(SCREEN.WIDTH + MARGIN.X["max"], MARGIN.Y["top"] - 50);
        _position = _initialPosition;
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Soraka");

        _bounds = new((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
    }

    public override void Update(GameTime gameTime)
    {
        if (Math.Ceiling(TimeToEnter) > 0)
        {
            TimeToEnter -= gameTime.ElapsedGameTime.TotalSeconds;
            return;
        }

        OnScreen = _position.X >= -Texture.Width;

        if (!OnScreen || !IsAlive)
        {
            _position = _initialPosition;
            _bounds.X = (int)_initialPosition.X;

            IsAlive = true;
            Points = RandomManager.GetRandomPoints();
            TimeToEnter = RandomManager.GetRandomTime();
        }

        var toLeft = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position.X -= toLeft;
        _bounds.X = (int)_position.X;
    }

    public override void Draw(SpriteBatch spriteBatch) =>
        spriteBatch.Draw(Texture, _position, Color.White);

    public override void HandleCollision()
    {
        IsAlive = false;
    }
}
