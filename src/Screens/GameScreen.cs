using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private readonly GraphicsDeviceManager _graphicsDevice;
    private Texture2D _background;

    public GameScreen(GraphicsDeviceManager graphics)
    {
        _graphicsDevice = graphics;
    }

    public void Initialize() { }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
    }

    public void Update(GameTime gameTime) { }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
    }
}
