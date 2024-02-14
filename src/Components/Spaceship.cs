using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Spaceship : IEntity
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Bounds { get; set; }
    private const int _speed = 5;

    public Spaceship(Vector2 initialPosition)
    {
        Position = initialPosition;
    }

    public void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Spaceship");
        Bounds = new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    }

    public void Update(GameTime gameTime)
    {
        Movement();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
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
