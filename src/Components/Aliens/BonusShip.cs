using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class BonusShip : IEntity
{
    private Vector2 _position;
    private Vector2 _initialPosition;
    private Rectangle _bounds;
    public Texture2D Texture { get; set; }
    public int Points { get; set; }
    public bool OnScreen { get; set; } = false;
    public float Speed { get; set; } = 100f;
    public double TimeToEnter { get; set; }

    public BonusShip()
    {
        var x = SCREEN.WIDTH + MARGIN.X["min"];
        var y = MARGIN.Y["top"] - 50;

        _position = new(x, y);
        _initialPosition = new(x, y);

        TimeToEnter = RandomManager.GetRandomTime();
        Points = RandomManager.GetRandomPoints();
    }

    public void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Soraka");
    }

    public void Update(GameTime gameTime)
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

    public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, _position, Color.White);
}
