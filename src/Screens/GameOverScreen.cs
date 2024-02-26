using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class GameOverScreen : IBaseScreen
{
    private readonly SpaceInvadersGame _game;
    private Texture2D _background, _gameOver, _enter;
    private string _playerName = "";
    private SpriteFont _font;
    private int _cursorPosition;
    private bool _blinkingCursor;
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
        _font = content.Load<SpriteFont>("Fonts/Press Start 2P");
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
                if (IsLetter(key))
                {
                    AddLetterName(key);
                }
                else if (key == Keys.Back && _playerName.Length > 0)
                {
                    RemoveLetterName();
                }
            }
        }

        _blinkingCursor = !_blinkingCursor;

        if (keyboard.IsKeyDown(Keys.Enter))
        {
            Thread.Sleep(50);
            //adicionar método para salvar dados
            _game.ChangeScreen(new StartScreen(_game));
            _playerName = "";
            ScoreManager.Reset();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(_gameOver, new Vector2(Screen.Width / 2 - _gameOver.Width / 2, 350), Color.White);
        spriteBatch.Draw(_enter, new Vector2(550, 758), Color.White);

        var score = ScoreManager.Score;

        spriteBatch.DrawString(_font, "Total Score",
            new Vector2((Screen.Width - _font.MeasureString("Total Score").X) / 2, 500), Color.White);
        spriteBatch.DrawString(_font, score.ToString(),
            new Vector2((Screen.Width - _font.MeasureString(score.ToString()).X) / 2, 520), Color.White);

        spriteBatch.DrawString(_font, _playerName,
            new Vector2((Screen.Width - _font.MeasureString(_playerName).X) / 2, 600), Color.White);

        if (_blinkingCursor)
        {
            spriteBatch.DrawString(_font, "|", new Vector2(
                (Screen.Width - _font.MeasureString(_playerName).X) / 2 +
                (_cursorPosition * _font.MeasureString("W").X),
                600), Color.White);
        }
    }

    private bool IsLetter(Keys key)
    {
        return key >= Keys.A && key <= Keys.Z;
    }

    private void AddLetterName(Keys key)
    {
        if (_playerName.Length < 12)
        {
            _playerName += key.ToString();
            _cursorPosition++;
        }
    }

    private void RemoveLetterName()
    {
        _playerName = _playerName.Remove(_playerName.Length - 1);
        _cursorPosition--;
    }
}
