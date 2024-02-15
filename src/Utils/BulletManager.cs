using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components;

namespace SpaceInvadersRetro.Utils;

public static class BulletManager
{
    private static readonly List<Bullet> _bullets = new();
    public static List<Bullet> Bullets => _bullets;

    public static Bullet CreateBullet(Vector2 position, Texture2D texture, Vector2 direction)
    {
        var bullet = new Bullet(position, texture, direction);
        _bullets.Add(bullet);
        return bullet;
    }

    public static void RemoveBullet(Bullet bullet)
    {
        _bullets.Remove(bullet);
    }

    public static void Update(GameTime gameTime)
    {
        foreach (var bullet in _bullets)
        {
            bullet?.Update(gameTime);
        }
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        foreach (var bullet in _bullets)
        {
            bullet?.Draw(spriteBatch);
        }
    }
}
