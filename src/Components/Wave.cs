using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Components.Aliens;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public static class Wave
{
    private static int _gap;
    private static bool _toLeft = true;
    public static List<AlienBase> Aliens { get; private set; } = new();

    public static void LoadAliensContent(ContentManager content)
    {
        Aliens.ForEach(a => a.LoadContent(content));
    }

    public static void Update(GameTime gameTime)
    {
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var toLeft = Vector2.UnitX * deltaTime * 20;
        var toRight = -Vector2.UnitX * deltaTime * 20;

        foreach (var alien in Aliens)
        {
            if (_toLeft) alien.Position += toLeft;
            else alien.Position += toRight;

            if (alien.Position.X >= SCREEN.WIDTH - MARGIN.X["min"] - SPRITE_SIZE.ALIENS["width"] || alien.Position.X <= MARGIN.X["min"])
            {
                _toLeft = !_toLeft;
            }
        }
    }

    public static void LoadAliens(int plusGap)
    {
        _gap += plusGap;

        for (int row = 0; row < 5; row++)
        {
            var y = MARGIN.Y["top"] + _gap + (SPRITE_SIZE.ALIENS["height"] + MARGIN.BETWEEN * 2) * row;

            for (int col = 0; col < 10; col++)
            {
                var x = MARGIN.X["max"] + (MARGIN.BETWEEN + SPRITE_SIZE.ALIENS["width"]) * col;
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
