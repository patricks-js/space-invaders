using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;

namespace SpaceInvadersRetro.Components.Aliens;

public abstract class AlienBase : EntityBase
{
    public abstract Texture2D Texture { get; set; }
    public abstract Vector2 Position { get; set; }
    public abstract bool IsAlive { get; set; }
    public abstract int Points { get; set; }
}
