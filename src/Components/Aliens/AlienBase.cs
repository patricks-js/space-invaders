using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Components;

public abstract class AlienBase : IEntity
{
    public abstract Texture2D Texture { get; set; }
    public abstract Rectangle Bounds { get; set; }
    public abstract Vector2 Position { get; set; }
    public abstract bool IsAlive { get; set; }
    public abstract int Points { get; set; }

    public abstract void Draw(SpriteBatch spriteBatch);

    public abstract void LoadContent(ContentManager content);

    public abstract void Update(GameTime gameTime);
}
