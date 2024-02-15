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
        var x = SCREEN.WIDTH + MARGIN.X["min"];
        var y = MARGIN.Y["top"] - 50;

        _position = new(x, y);
        _initialPosition = new(x, y);

        TimeToEnter = RandomManager.GetRandomTime();
        Points = RandomManager.GetRandomPoints();
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Soraka");
    }

    public override void Update(GameTime gameTime)
    {
        bool onScreen = _position.X >= -Texture.Width;

        if (Math.Ceiling(TimeToEnter) > 0)
        {
            TimeToEnter -= gameTime.ElapsedGameTime.TotalSeconds;
            return;
        }

        if (!onScreen)
        {
            _position = _initialPosition;
            Points = RandomManager.GetRandomPoints();
            TimeToEnter = RandomManager.GetRandomTime();
        }

        var toLeft = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position.X -= toLeft;
        _bounds.X -= (int)toLeft;
    }

    public override void Draw(SpriteBatch spriteBatch) =>
        spriteBatch.Draw(Texture, _position, Color.White);
}
