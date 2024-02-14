using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Screens;

namespace SpaceInvadersRetro.Utils;

public abstract class ScreenManager
{
    private static IBaseScreen _currentScreen;

    public static void Change(IBaseScreen screen)
    {
        _currentScreen = screen;
        _currentScreen.LoadContent();
    }

    public static void Initialize()
    {
        _currentScreen.Initialize();
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
