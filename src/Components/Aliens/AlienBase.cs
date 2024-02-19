using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Components.Aliens;

public abstract class AlienBase : EntityBase
{
    protected Rectangle[] _sprites;
    protected byte _spriteIdx = 0;
    protected float _interval = 1f;
    protected float _elapsedTime = 0f;

    public abstract Texture2D Texture { get; set; }
    public abstract Vector2 Position { get; set; }
    public abstract bool IsAlive { get; set; }
    public abstract int Points { get; set; }

    public void Animation()
    {
        if (_elapsedTime > _interval)
        {
            if (_spriteIdx == 0)
                _spriteIdx = 1;
            else
                _spriteIdx = 0;

            _elapsedTime = 0;
        }
    }
}
