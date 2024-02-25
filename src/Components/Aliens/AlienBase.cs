using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Components.Aliens;

public abstract class AlienBase : EntityBase
{
    protected Rectangle[] Sprites;
    protected byte SpriteIdx = 0;
    private const float Interval = 1f;
    protected float ElapsedTime = 0f;

    public abstract Texture2D Texture { get; set; }
    public abstract Vector2 Position { get; set; }
    public abstract bool IsAlive { get; set; }
    public abstract int Points { get; set; }

    protected void Animation()
    {
        if (!(ElapsedTime > Interval)) return;
        SpriteIdx = SpriteIdx == 0 ? (byte)1 : (byte)0;

        ElapsedTime = 0;
    }
}
