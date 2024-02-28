using System.Collections.Generic;

namespace SpaceInvadersRetro.Utils;

public readonly struct Margin
{
    public static readonly Dictionary<string, int> X = new() { { "min", 20 }, { "max", 82 } };
    public static readonly Dictionary<string, int> Y = new() { { "top", 140 }, { "bottom", 82 } };
    public const int Between = 12;
}

public readonly struct Screen
{
    public const int Width = 720;
    public const int Height = 896;
}

public readonly struct SpriteSize
{
    public static readonly Dictionary<string, int> Aliens =
        new() { { "width", 45 }, { "height", 36 } };

    public static readonly Dictionary<string, int> Barricade =
        new() { { "width", 80 }, { "height", 39 } };

    public static readonly Dictionary<string, int> Health =
        new() { { "width", 86 }, { "height", 43 } };

    public static readonly Dictionary<string, int> Spaceship =
        new() { { "width", 36 }, { "height", 36 } };
}

public readonly struct SpriteFrames
{
    public const int Aliens = 2;
}
