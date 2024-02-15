using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Utils;

public static class EntityManager
{
    private static readonly List<EntityBase> _entities = new();
    public static List<EntityBase> Entities => _entities;

    public static void AddEntity(EntityBase entity)
    {
        _entities.Add(entity);
    }

    public static EntityBase Search(int idx)
    {
        return _entities[idx];
    }

    public static void RemoveEntity(EntityBase entity)
    {
        _entities.Remove(entity);
    }

    public static void LoadContent(ContentManager content)
    {
        foreach (var entity in _entities)
        {
            entity.LoadContent(content);
        }
    }

    public static void Update(GameTime gameTime)
    {
        foreach (var entity in _entities)
        {
            entity.Update(gameTime);
        }
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        foreach (var entity in _entities)
        {
            entity.Draw(spriteBatch);
        }
    }
}
