using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private readonly GraphicsDeviceManager _graphicsDevice;

    public GameScreen(GraphicsDeviceManager graphics)
    {
        _graphicsDevice = graphics;
    }

    public void Initialize() { }

    public void LoadContent(ContentManager content) { }

    public void Update(GameTime gameTime) { }

    public void Draw(SpriteBatch spriteBatch) { }
}
