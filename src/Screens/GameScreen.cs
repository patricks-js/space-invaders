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
    private SpriteFont _font;

    public GameScreen(SpaceInvadersGame game)
    {
        _game = game;
    }

    ~GameScreen()
    {
        Wave.Aliens.Clear();
        EntityManager.Entities.Clear();
        BulletManager.Bullets.Clear();
        ScoreManager.Reset();
        SpaceshipHealthManager.Reset();
    }

    public void Initialize()
    {
        LoadEntities();

        var x = Screen.Width - Margin.X["min"] - SpriteSize.Health["width"];
        var y = Margin.X["min"] + Margin.X["min"] - SpriteSize.Health["height"] / 2;
        var healthPosition = new Vector2(x, y);

        SpaceshipHealthManager.Initialize(healthPosition);
        SoundManager.StopSong();
    }

    public void LoadContent(ContentManager content)
    {
        _background = content.Load<Texture2D>("Images/Background");
        _font = content.Load<SpriteFont>("Fonts/Press Start 2P");
        SpaceshipHealthManager.LoadContent(content);
        EntityManager.LoadContent(content);
    }

    public void Update(GameTime gameTime)
    {
        EntityManager.Update(gameTime);
        BulletManager.Update(gameTime);
        Wave.Update(gameTime, _game);

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

        spriteBatch.DrawString(
            _font,
            $"Score: {score}",
            new Vector2(Margin.X["min"], Margin.X["min"] + Margin.X["min"]),
            Color.White
        );

        SpaceshipHealthManager.Draw(spriteBatch);
        EntityManager.Draw(spriteBatch);
        BulletManager.Draw(spriteBatch);
    }

    private void LoadEntities()
    {
        // Spaceship
        var spaceshipPosition = new Vector2(
            (float)Screen.Width / 2 - (float)SpriteSize.Spaceship["width"] / 2,
            Screen.Height - Margin.Y["bottom"]
        );

        EntityManager.AddEntity(new Spaceship(spaceshipPosition, _game));

        // Bullet
        BulletManager.Bullets.ForEach(EntityManager.AddEntity);

        LoadBarricades();
        LoadAliens();
    }

    private void LoadBarricades()
    {
        for (int i = 0; i < 4; i++)
        {
            var y = Screen.Height - Margin.Y["top"];
            var x = Margin.X["max"] + Margin.X["min"] + 6 + (SpriteSize.Barricade["width"] + Margin.Between * 5) * i;
            EntityManager.AddEntity(new Barricade(new Vector2(x, y)));
        }
    }

    private void LoadAliens()
    {
        EntityManager.AddEntity(new BonusShip());

        Wave.LoadAliens(0);
        Wave.Aliens.ForEach(EntityManager.AddEntity);
    }
}
