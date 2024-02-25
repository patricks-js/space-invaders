using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components.Aliens;

public class BonusShip : AlienBase
{
    private Vector2 _position;
    private Vector2 _initialPosition;
    private Rectangle _bounds;
    private int _points;
    private double _timeToEnter;

    public bool OnScreen { get; set; } = false;
    public float Speed { get; set; } = 100f;
    public override bool IsAlive { get; set; } = true;
    public override Texture2D Texture { get; set; }
    public double TimeToEnter
    {
        get => _timeToEnter;
        set => _timeToEnter = value;
    }
    public override int Points
    {
        get => _points;
        set => _points = value;
    }
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
            _points = RandomManager.GetRandomPoints();
            _timeToEnter = RandomManager.GetRandomTime();
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
        ScoreManager.Increment(_points);
        SoundManager.PlaySoundEffect("invaderkilled");
    }
}
