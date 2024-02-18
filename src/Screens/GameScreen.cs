using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private Texture2D _background;

    public void Initialize()
    {
        LoadEntities();

        SoundManager.StopSong();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        EntityManager.LoadContent(content);
    }

    public void Update(GameTime gameTime)
    {
        EntityManager.Update(gameTime);
        BulletManager.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        EntityManager.Draw(spriteBatch);
        BulletManager.Draw(spriteBatch);
    }

    private static void LoadEntities()
    {
        // Spaceship
        var spaceshipPosition = new Vector2(SCREEN.WIDTH / 2, SCREEN.HEIGHT - MARGIN.Y["bottom"]);
        EntityManager.AddEntity(new Spaceship(spaceshipPosition));

        // Bullet
        BulletManager.Bullets.ForEach(b => EntityManager.AddEntity(b));

        // Aliens
        EntityManager.AddEntity(new BonusShip());
    }
}
