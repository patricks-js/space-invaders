using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using SpaceInvadersRetro.Components.Aliens;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public static class Wave
{
    private static List<AlienBase> _aliens = new();
    public static List<AlienBase> Aliens
    {
        get => _aliens;
        set => _aliens = value;
    }

    public static void LoadAliensContent(ContentManager content)
    {
        _aliens.ForEach(a => a.LoadContent(content));
    }

    public static void LoadAliens()
    {
        for (int row = 0; row < 5; row++)
        {
            var y = MARGIN.Y["top"] + (SPRITE_SIZE.ALIENS["height"] + MARGIN.BETWEEN * 2) * row;

            for (int col = 0; col < 10; col++)
            {
                var x = MARGIN.X["max"] + (MARGIN.BETWEEN + SPRITE_SIZE.ALIENS["width"]) * col;
                MakeLines(row, x, y);
            }
        }
    }

    public static void RemoveAlien(AlienBase alien)
    {
        _aliens.Remove(alien);
    }

    private static void MakeLines(int row, int x, int y)
    {
        switch (row)
        {
            case 0:
                _aliens.Add(new Carry(new(x, y)));
                break;
            case 1:
                _aliens.Add(new Assassin(new(x, y)));
                break;
            case 2:
                _aliens.Add(new Jungle(new(x, y)));
                break;
            case 3:
                _aliens.Add(new Bruiser(new(x, y)));
                break;
            case 4:
                _aliens.Add(new Tank(new(x, y)));
                break;
        }
    }
}
