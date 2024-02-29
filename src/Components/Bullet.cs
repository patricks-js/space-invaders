using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Bullet : EntityBase
{
    private readonly Vector2 _direction;
    private Texture2D Texture { get; set; }
    private Vector2 _position;
    public Rectangle _bounds;
    private float Speed { get; set; }
    public override Rectangle Bounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    public Bullet(Vector2 initialPosition, Texture2D texture, Vector2 direction, float speed)
    {
        Texture = texture;
        _position = initialPosition;
        _direction = direction;
        _bounds = new Rectangle((int)_position.X - 3 / 2, (int)_position.Y - 9, Texture.Width, Texture.Height);
        Speed = speed;
    }

    public override void Update(GameTime gameTime)
    {
        var bulletUp = _direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        _position += bulletUp;

        _bounds.Location += bulletUp.ToPoint();
    }

    public override void Draw(SpriteBatch spriteBatch) =>
        spriteBatch.Draw(Texture, _position, Color.White);

    public bool IsOffScreen() => _position.Y + _bounds.Height < 0 || _position.Y >= Screen.Height;

    public override void LoadContent(ContentManager content) { }

    public override void HandleCollision() { }
}
