using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components;
using SpaceInvadersRetro.Components.Aliens;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Screens;

public class GameScreen : IBaseScreen
{
    private readonly SpaceInvadersGame _game;
    private Texture2D _background;
    // private SpriteFont _font;

    public GameScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    public void Initialize()
    {
        LoadEntities();

        SoundManager.StopSong();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        //Wave.LoadAliensContent(content);
        //_font = content.Load<SpriteFont>("Fonts/GameFont");
        EntityManager.LoadContent(content);
    }

    public void Update(GameTime gameTime)
    {
        EntityManager.Update(gameTime);
        BulletManager.Update(gameTime);
        Wave.Update(gameTime);

        if (Wave.Aliens.Count <= 0)
        {
            Wave.LoadAliens(40);
            Wave.LoadAliensContent(_game.Content);
            Thread.Sleep(100);
            Wave.Aliens.ForEach(EntityManager.AddEntity);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var score = ScoreManager.Score;

        spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        /*
        spriteBatch.DrawString(
            _font,
            $"Score: {score}",
            new Vector2(MARGIN.X["min"], MARGIN.X["min"] + MARGIN.X["min"]),
            Color.White
        );
        */

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

        // Barricade
        for (int i = 0; i < 4; i++)
        {
            var y = SCREEN.HEIGHT - MARGIN.Y["top"];
            var x = MARGIN.X["max"] + MARGIN.X["min"] + 10 + (SPRITE_SIZE.BARRICADE["width"] + MARGIN.BETWEEN * 5) * i;
            EntityManager.AddEntity(new Barricade(new Vector2(x, y)));
        }

        Wave.LoadAliens(0);
        var wave = Wave.Aliens;
        wave.ForEach(EntityManager.AddEntity);
    }
}
