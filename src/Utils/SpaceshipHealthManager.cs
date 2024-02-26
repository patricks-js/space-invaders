using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Utils;

public static class SpaceshipHealthManager
{
    private static Texture2D _texture;
    private static Vector2 _position;
    private static readonly Rectangle[] Sprites = new Rectangle[6];

    public static int Health { get; private set; } = 3;

    public static void Initialize(Vector2 position)
    {
        _position = position;

        var w = SpriteSize.Health["width"];
        var h = SpriteSize.Health["height"];

        Sprites[5] = new Rectangle(0, 0, w, h);
        Sprites[4] = new Rectangle(0, h, w, h);
        Sprites[3] = new Rectangle(0, h * 2, w, h);
        Sprites[2] = new Rectangle(0, h * 3, w, h);
        Sprites[1] = new Rectangle(0, h * 4, w, h);
        Sprites[0] = new Rectangle(0, h * 5, w, h);
    }

    public static void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Sprites/Health");
    }

    public static void DecreaseHealth()
    {
        Health--;
    }

    public static void IncreaseHealth()
    {
        if (Health <= 5)
        {
            Health++;
        }
    }

    public static void Reset() => Health = 3;

    public static void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Sprites[Health], Color.White);
    }
}
