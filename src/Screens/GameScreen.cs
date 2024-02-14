using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private readonly GraphicsDeviceManager _graphicsDevice;
    private Texture2D _background;
    private Song _music;

    public GameScreen(GraphicsDeviceManager graphics)
    {
        _graphicsDevice = graphics;
    }

    public void Initialize() { }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _music = content.Load<Song>("Sounds/spaceinvadersmusic");

        MediaPlayer.Volume -= .7f;
        MediaPlayer.Play(_music);
    }

    public void Update(GameTime gameTime) { }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
    }
}
