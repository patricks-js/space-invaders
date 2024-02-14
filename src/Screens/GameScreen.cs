using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceInvadersRetro.Components;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private readonly GraphicsDeviceManager _graphicsDevice;
    private Texture2D _background;
    private Song _music;
    private Spaceship _spaceship;

    public GameScreen(GraphicsDeviceManager graphics)
    {
        _graphicsDevice = graphics;
    }

    public void Initialize()
    {
        var spaceshipPosition = new Vector2(SCREEN.WIDTH / 2, SCREEN.HEIGHT - MARGIN.Y["bottom"]);
        _spaceship = new Spaceship(spaceshipPosition);
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _music = content.Load<Song>("Sounds/spaceinvadersmusic");
        _spaceship.LoadContent(content);

        MediaPlayer.Volume -= .7f;
        MediaPlayer.Play(_music);
    }

    public void Update(GameTime gameTime)
    {
        _spaceship.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        _spaceship.Draw(spriteBatch);
    }
}
