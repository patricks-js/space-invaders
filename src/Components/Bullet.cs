using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Bullet
{
    public Texture2D Texture { get; set; }
    public Vector2 _position;
    public Rectangle _bounds;
    public float Speed { get; set; } = 500f;

    public Bullet(Vector2 initialPosition, Texture2D texture)
    {
        Texture = texture;
        _position = initialPosition;
        _bounds = new((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
    }

    public void GoUp(GameTime gameTime)
    {
        var bulletUp = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        _position.Y -= bulletUp;

        _bounds.Y -= (int)bulletUp;
    }

    public void GoDown(GameTime gameTime)
    {
        var bulletUp = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        _position.Y += bulletUp;

        _bounds.Y += (int)bulletUp;
    }

    public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, _position, Color.White);

    public bool IsOffScreen() => _position.Y + _bounds.Height < 0 || _position.Y >= SCREEN.HEIGHT;
}
