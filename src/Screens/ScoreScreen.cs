using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class ScoreScreen : IBaseScreen
{
    private Texture2D _background,
        _logo;
    private Texture2D _backspace;
    private readonly SpaceInvadersGame _game;

    public ScoreScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    public void Initialize()
    {
        SoundManager.LoadSong("spaceinvadersmusic");
        SoundManager.PlaySong(.9f, true);
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _logo = content.Load<Texture2D>("Images/Logo");
        _backspace = content.Load<Texture2D>("Images/Backspace");
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Back))
        {
            _game.ChangeScreen(new StartScreen(_game));
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(
            _logo,
            new Vector2(SCREEN.WIDTH / 2 - _logo.Width / 2, MARGIN.Y["bottom"]),
            Color.White
        );
        spriteBatch.Draw(_backspace, new Vector2(50, 758), Color.White);
    }
}
