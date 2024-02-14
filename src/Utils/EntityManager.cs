using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Utils;

public static class EntityManager
{
    public static List<IEntity> Entities { get; set; } = new();

    public static void LoadContent(ContentManager content)
    {
        foreach (var entity in Entities)
        {
            entity.LoadContent(content);
        }
    }

    public static void Update(GameTime gameTime)
    {
        foreach (var entity in Entities)
        {
            entity.Update(gameTime);
        }
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        foreach (var entity in Entities)
        {
            entity.Draw(spriteBatch);
        }
    }
}
