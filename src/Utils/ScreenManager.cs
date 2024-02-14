using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Screens;

namespace SpaceInvadersRetro.Utils;

public abstract class ScreenManager
{
    private static BaseScreen _currentScreen;

    public static void Change(BaseScreen screen)
    {
        _currentScreen = screen;
        _currentScreen.LoadContent();
    }

    public static void Initialize()
    {
        _currentScreen.Initialize();
    }

    public static void LoadContent()
    {
        _currentScreen.LoadContent();
    }

    public static void Update(GameTime gameTime)
    {
        _currentScreen.Update(gameTime);
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        _currentScreen.Draw(spriteBatch);
    }
}
