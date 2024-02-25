using System.Collections.Generic;

namespace SpaceInvadersRetro.Utils;

public readonly struct MARGIN
{
    public static readonly Dictionary<string, int> X = new() { { "min", 20 }, { "max", 82 } };
    public static readonly Dictionary<string, int> Y = new() { { "top", 200 }, { "bottom", 82 } };
    public static readonly int BETWEEN = 12;
}

public readonly struct SCREEN
{
    public static readonly int WIDTH = 720;
    public static readonly int HEIGHT = 896;
}

public readonly struct SPRITE_SIZE
{
    public static readonly Dictionary<string, int> ALIENS =
        new() { { "width", 45 }, { "height", 36 } };
    public static readonly Dictionary<string, int> BARRICADE =
        new() { { "width", 80 }, { "height", 115 } };
}

public readonly struct SPRITE_FRAMES
{
    public static readonly int ALIENS = 2;
}
