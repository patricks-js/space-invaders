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
    private Texture2D _selectStart;

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
        _selectStart = content.Load<Texture2D>("Images/SelectStart");
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Space))
        {
            _game.ChangeScreen(new GameScreen());
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
        spriteBatch.Draw(_selectStart, new Vector2(200, 350), Color.White);
    }
}
