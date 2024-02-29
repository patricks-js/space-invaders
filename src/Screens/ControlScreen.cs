using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class ControlScreen : IBaseScreen
{
    public ControlScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    private SpaceInvadersGame _game;

    private Texture2D _background,
        _logo,
        _controlsImage;
    private Texture2D _backspace;

    public void Initialize()
    {
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _logo = content.Load<Texture2D>("Images/Logo");
        _controlsImage = content.Load<Texture2D>("Images/ControlsImage");
        _backspace = content.Load<Texture2D>("Images/Backspace");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(
            _logo,
            new Vector2(Screen.Width / 2 - _logo.Width / 2, Margin.Y["bottom"]),
            Color.White
        );
        spriteBatch.Draw(_controlsImage, new Vector2(100, 350), Color.White);
        spriteBatch.Draw(_backspace, new Vector2(50, 758), Color.White);
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Back))
        {
            _game.ChangeScreen(new StartScreen(_game));
        }
    }
}
