using System.Collections.Generic;
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

    private Texture2D _backspace, _highScore;
    private SpriteFont _font;
    private readonly SpaceInvadersGame _game;
    private List<PlayerData> _playerScores;

    public ScoreScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    public void Initialize()
    {
        _playerScores = ScoreManager.LoadScoreList();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _logo = content.Load<Texture2D>("Images/Logo");
        _backspace = content.Load<Texture2D>("Images/Backspace");
        _highScore = content.Load<Texture2D>("Images/HighScores");
        _font = content.Load<SpriteFont>("Fonts/Press Start 2P");

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
            new Vector2(Screen.Width / 2 - _logo.Width / 2, Margin.Y["bottom"]),
            Color.White
        );
        spriteBatch.Draw(_backspace, new Vector2(50, 758), Color.White);
        spriteBatch.Draw(_highScore, new Vector2(Screen.Width/2 - _highScore.Width/2 , 350), Color.White);


        int entryY = 400;
        int top = 1;
        foreach (PlayerData playerData in _playerScores)
        {
            spriteBatch.DrawString(_font, $"{top}.{playerData.Name} - {playerData.Score}", new Vector2(Screen.Width / 3, entryY), Color.White);
            entryY += 40;
            top++;
        }



    }
}
