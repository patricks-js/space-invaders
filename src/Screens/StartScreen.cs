using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class StartScreen : IBaseScreen
{
    private readonly SpaceInvadersGame _game;
    private Texture2D _background;
    private Texture2D _logo;
    private Texture2D _select, _enter;

    private Song _bgMusic;

    private bool _isKeyPress;

    private readonly Texture2D[] _menu = new Texture2D[3];

    private int _choice;

    public StartScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    public void Initialize()
    {
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _logo = content.Load<Texture2D>("Images/Logo");
        _select = content.Load<Texture2D>("Images/Select");
        _enter = content.Load<Texture2D>("Images/Enter");
        _bgMusic = content.Load<Song>("Sounds/spaceinvadersmusic");

        _menu[0] = content.Load<Texture2D>("Images/SelectStart");
        _menu[1] = content.Load<Texture2D>("Images/SelectScore");
        _menu[2] = content.Load<Texture2D>("Images/SelectControls");

        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume -= 0.8f;
        MediaPlayer.Play(_bgMusic);
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Enter))
        {
            switch (_choice)
            {
                case 0:
                    _game.ChangeScreen(new GameScreen(_game));
                    break;
                case 1:
                    _game.ChangeScreen(new ScoreScreen(_game));
                    break;
                case 2:
                    _game.ChangeScreen(new ControlScreen(_game));
                    break;
            }
        }

        if (keyboard.IsKeyDown(Keys.S) && !_isKeyPress)
        {
            _isKeyPress = true;
            Thread.Sleep(50);
            _choice++;
            if (_choice > 2)
            {
                _choice = 0;
            }
        }
        if (keyboard.IsKeyDown(Keys.W) && !_isKeyPress)
        {
            _isKeyPress = true;
            Thread.Sleep(50);
            _choice--;
            if (_choice < 0)
            {
                _choice = 2;
            }
        }
        if (keyboard.IsKeyUp(Keys.S))
        {
            _isKeyPress = false;
        }
        if (keyboard.IsKeyUp(Keys.W))
        {
            _isKeyPress = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(
            _logo,
            new Vector2((float)Screen.Width / 2 - (float)_logo.Width / 2, Margin.Y["bottom"]),
            Color.White
        );

        spriteBatch.Draw(_menu[_choice], new Vector2(200, 350), Color.White);

        spriteBatch.Draw(_select, new Vector2(50, 720), Color.White);
        spriteBatch.Draw(_enter, new Vector2(550, 758), Color.White);
    }
}
