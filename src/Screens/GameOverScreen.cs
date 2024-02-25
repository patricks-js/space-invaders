using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Screens;
public class GameOverScreen : IBaseScreen
{
    private SpaceInvadersGame _game;
    private Texture2D _background, _gameOver, _enter;
    private string _playerName = "";
    //private SpriteFont _font;  // Load font in LoadContent()
    //private int _cursorPosition;  // Index of currently selected character
    private bool _blinkingCursor;  // State of the blinking cursor
    private KeyboardState _currentKeyboardState;
    private KeyboardState _previousKeyboardState;

    public GameOverScreen(SpaceInvadersGame game)
    {
        _game = game;
    }
    public void Initialize()
    {
        //throw new System.NotImplementedException();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _gameOver = content.Load<Texture2D>("Images/GameOver");
        _enter = content.Load<Texture2D>("Images/Enter");
    }
    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();

        Keys[] pressedKeys = _currentKeyboardState.GetPressedKeys();
        foreach (Keys key in pressedKeys)
        {
            if (_previousKeyboardState.IsKeyUp(key))
            {
                if (key == Keys.Enter)
                {
                    _playerName = "";
                }
                else if (key == Keys.Back && _playerName.Length > 0)
                {
                    _playerName = _playerName.Remove(_playerName.Length - 1);
                }
                else
                {
                    _playerName += key.ToString();
                }
            }
        }

        Console.WriteLine(_playerName);

        _blinkingCursor = !_blinkingCursor;

        if (keyboard.IsKeyDown(Keys.Enter))
        {
             _game.ChangeScreen(new StartScreen(_game));
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(_gameOver, new Vector2(100, 350), Color.White);
        spriteBatch.Draw(_enter, new Vector2(550, 758), Color.White);

        // spriteBatch.DrawString(_font, _playerName, new Vector2(300, 500), Color.White);
        //
        // // Draw blinking cursor
        // if (_blinkingCursor)
        // {
        //     spriteBatch.DrawString(_font, "|", new Vector2(300 + _cursorPosition * _font.MeasureString("W").X, 500), Color.White);
        // }
    }

}
