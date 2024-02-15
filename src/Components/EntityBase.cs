using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Interfaces;

public abstract class EntityBase
{
    public abstract Rectangle Bounds { get; set; }

    public abstract void LoadContent(ContentManager content);
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
    public abstract void HandleCollision();
}
