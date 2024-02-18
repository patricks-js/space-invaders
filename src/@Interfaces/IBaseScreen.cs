using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Interfaces;

public interface IBaseScreen
{
    void Initialize();
    void LoadContent(ContentManager content);
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}
