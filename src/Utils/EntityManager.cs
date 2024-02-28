using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components;
using SpaceInvadersRetro.Components.Aliens;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Utils;

public static class EntityManager
{
    private static readonly List<EntityBase> EntitiesToRemove = new();
    public static List<EntityBase> Entities { get; } = new();

    public static void AddEntity(EntityBase entity)
    {
        Entities.Add(entity);
    }

    public static void RemoveEntity(EntityBase entity)
    {
        EntitiesToRemove.Add(entity);
    }

    public static void LoadContent(ContentManager content)
    {
        Entities.ForEach(e => e?.LoadContent(content));
    }

    public static void Update(GameTime gameTime)
    {
        Entities.ForEach(e => e?.Update(gameTime));

        EntitiesToRemove.ForEach(e =>
        {
            Entities.Remove(e);
            if (e is AlienBase @base)
            {
                Wave.RemoveAlien(@base);
            }
        });

        EntitiesToRemove.Clear();
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        Entities.ForEach(e => e?.Draw(spriteBatch));
    }
}
