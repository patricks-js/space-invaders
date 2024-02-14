using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Screens;

namespace SpaceInvadersRetro.Utils;

public static class ScreenManager
{
    private static IBaseScreen _currentScreen;

    public static void Change(IBaseScreen screen)
    {
        _currentScreen = screen;
    }

    public static void Initialize(ContentManager content)
    {
        _currentScreen.Initialize();
        _currentScreen.LoadContent(content);
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
