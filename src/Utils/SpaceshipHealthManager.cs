using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Utils;

public static class SpaceshipHealthManager
{
    // private Texture2D _texture;

    public static int Health { get; set; } = 3;

    public static void DecreaseHealth()
    {
        Health--;
    }

    public static void IncreaseHealth()
    {
        if (Health <= 6)
        {
            Health++;
        }
    }

    public static void Reset() => Health = 3;
}
