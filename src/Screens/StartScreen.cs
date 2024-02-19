using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Screens;
using SpaceInvadersRetro.Utils;

public class StartScreen : IBaseScreen
{
    private Texture2D _background;
    private Texture2D _selectStart;

    //private int choice = 0;

    public void Initialize()
    {
        SoundManager.LoadSong("spaceinvadersmusic");
        SoundManager.PlaySong(.9f, true);
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _selectStart = content.Load<Texture2D>("Images/SelectStart");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(_selectStart, new Vector2(200, 350), Color.White);
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Space))
        {
            ScreenManager.Change(new GameScreen());
        }
    }
}
