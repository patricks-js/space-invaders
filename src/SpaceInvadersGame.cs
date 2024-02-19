using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Screens;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro;

public class SpaceInvadersGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IBaseScreen _currentScreen;

    public SpaceInvadersGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = SCREEN.WIDTH;
        _graphics.PreferredBackBufferHeight = SCREEN.HEIGHT;
        _graphics.ApplyChanges();

        SoundManager.CreateInstance(Content);

        _currentScreen = new StartScreen(this);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _currentScreen.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        _currentScreen.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _currentScreen.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void ChangeScreen(IBaseScreen @base)
    {
        @base.Initialize();
        @base.LoadContent(Content);

        _currentScreen = @base;
    }
}
