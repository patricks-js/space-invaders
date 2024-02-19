using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class StartScreen : IBaseScreen
{
    private SpaceInvadersGame _game;
    private Texture2D _background;
    private Texture2D _logo;
    private Texture2D _selectStart, _selectScore, _selectControls;
    private bool IsKeyPress = false;
 
    private Texture2D [] Menu = new Texture2D [3];

    private int _choice = 0;

    public StartScreen(SpaceInvadersGame game)
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

        Menu[0] = _selectStart = content.Load<Texture2D>("Images/SelectStart");
        Menu[1] = _selectScore = content.Load<Texture2D>("Images/SelectScore");
        Menu[2] = _selectControls = content.Load<Texture2D>("Images/SelectControls");

    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Enter))
        {
            switch(_choice){
                case 0:
                _game.ChangeScreen(new GameScreen());
                break;
                case 1:
                _game.ChangeScreen(new ScoreScreen(_game));
                break;
                case 2:
                _game.ChangeScreen(new ControlScreen(_game));
                break;
                
            }
        }

        if(keyboard.IsKeyDown(Keys.S)&& !IsKeyPress){
            IsKeyPress = true;
            Thread.Sleep(50);
            _choice++;
            if (_choice > 2)
            {
                _choice = 0;
            }
        }
        if(keyboard.IsKeyDown(Keys.W) && !IsKeyPress){
            IsKeyPress = true;
            Thread.Sleep(50);
            _choice--;
            if(_choice < 0){
                _choice = 2;
            }
        }
        if(keyboard.IsKeyUp(Keys.S) ){
            IsKeyPress = false;
     
        }
        if(keyboard.IsKeyUp(Keys.W)){
            IsKeyPress = false;
       
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

        spriteBatch.Draw(Menu[_choice], new Vector2(200, 350), Color.White);

    }
}
