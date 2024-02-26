using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SpaceInvadersRetro.Components.Aliens;
using SpaceInvadersRetro.Screens;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public static class Wave
{
    private static int _gap;
    private static bool _toLeft = true;
    private const int Speed = 20;
    public static List<AlienBase> Aliens { get; private set; } = new();

    public static void LoadAliensContent(ContentManager content)
    {
        Aliens.ForEach(a => a.LoadContent(content));
    }

    public static void Update(GameTime gameTime, SpaceInvadersGame game)
    {
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var toLeft = Vector2.UnitX * deltaTime * Speed;
        var toRight = -Vector2.UnitX * deltaTime * Speed;
        var toDown = new Vector2(0, Speed);

        foreach (var alien in Aliens)
        {
            if (_toLeft)
                alien.Position += toLeft;
            else
                alien.Position += toRight;

            var inLeftSide = alien.Position.X >= Screen.Width - Margin.X["min"] - SpriteSize.Aliens["width"];
            var inRightSide = alien.Position.X <= Margin.X["min"];

            if (inLeftSide || inRightSide)
            {
                _toLeft = !_toLeft;
                Aliens.ForEach(alienToDown => alienToDown.Position += toDown);
            }
        }

        EntityManager.Entities.ForEach(entity =>
        {
            if (entity is AlienBase or Bullet) return;

            if (Aliens.Any(alien => alien.Bounds.Intersects(entity.Bounds)))
            {
                game.ChangeScreen(new GameOverScreen(game));
            }
        });
    }

    public static void LoadAliens(int plusGap)
    {
        _gap += plusGap;

        for (int row = 0; row < 5; row++)
        {
            var y = Margin.Y["top"] + _gap + (SpriteSize.Aliens["height"] + Margin.Between * 2) * row;

            for (int col = 0; col < 10; col++)
            {
                var x = Margin.X["max"] + (Margin.Between + SpriteSize.Aliens["width"]) * col;
                MakeLines(row, x, y);
            }
        }
    }

    public static void RemoveAlien(AlienBase alien)
    {
        Aliens.Remove(alien);
    }

    private static void MakeLines(int row, int x, int y)
    {
        var position = new Vector2(x, y);

        switch (row)
        {
            case 0:
                Aliens.Add(new Carry(position));
                break;
            case 1:
                Aliens.Add(new Assassin(position));
                break;
            case 2:
                Aliens.Add(new Jungle(position));
                break;
            case 3:
                Aliens.Add(new Bruiser(position));
                break;
            case 4:
                Aliens.Add(new Tank(position));
                break;
        }
    }
}
