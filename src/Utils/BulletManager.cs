using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components;

namespace SpaceInvadersRetro.Utils;

public static class BulletManager
{
    public static List<Bullet> Bullets { get; } = new();

    public static Bullet CreateBullet(
        Vector2 position,
        Texture2D texture,
        Vector2 direction,
        float speed
    )
    {
        var bullet = new Bullet(position, texture, direction, speed);
        Bullets.Add(bullet);
        return bullet;
    }

    public static void RemoveBullet(Bullet bullet) => Bullets.Remove(bullet);

    public static void Update(GameTime gameTime) =>
        Bullets.ForEach(bullet => bullet?.Update(gameTime));

    public static void Draw(SpriteBatch spriteBatch) =>
        Bullets.ForEach(bullet => bullet?.Draw(spriteBatch));
}
