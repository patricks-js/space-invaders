using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public abstract class AlienBase : EntityBase
{
    public abstract Texture2D Texture { get; set; }
    public abstract Vector2 Position { get; set; }
    public abstract bool IsAlive { get; set; }
    public abstract int Points { get; set; }
}
