using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceInvadersRetro.Components;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private Texture2D _background;
    private Song _music;

    public void Initialize()
    {
        LoadEntities();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _music = content.Load<Song>("Sounds/spaceinvadersmusic");
        EntityManager.LoadContent(content);

        MediaPlayer.Volume -= .7f;
        MediaPlayer.Play(_music);
    }

    public void Update(GameTime gameTime)
    {
        EntityManager.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        EntityManager.Draw(spriteBatch);
    }

    private static void LoadEntities()
    {
        // Spaceship
        var spaceshipPosition = new Vector2(SCREEN.WIDTH / 2, SCREEN.HEIGHT - MARGIN.Y["bottom"]);
        EntityManager.AddEntity(new Spaceship(spaceshipPosition));

        // Aliens
    }
}
