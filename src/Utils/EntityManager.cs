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
    private static readonly List<EntityBase> _entities = new();
    private static readonly List<EntityBase> _entitiesToRemove = new();
    public static List<EntityBase> Entities => _entities;

    public static void AddEntity(EntityBase entity) => _entities.Add(entity);

    public static EntityBase Search(int idx) => _entities[idx];

    public static void RemoveEntity(EntityBase entity) => _entitiesToRemove.Add(entity);

    public static void LoadContent(ContentManager content) =>
        _entities.ForEach(e => e?.LoadContent(content));

    public static void Update(GameTime gameTime)
    {
        _entities.ForEach(e => e?.Update(gameTime));

        _entitiesToRemove.ForEach(e =>
        {
            _entities.Remove(e);
        });

        _entitiesToRemove.Clear();
    }

    public static void Draw(SpriteBatch spriteBatch) =>
        _entities.ForEach(e => e?.Draw(spriteBatch));
}
