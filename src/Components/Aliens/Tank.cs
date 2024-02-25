using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components.Aliens;

public class Tank : AlienBase
{
    private Vector2 _position;
    private Rectangle _bounds;

    public override Texture2D Texture { get; set; }
    public override bool IsAlive { get; set; } = true;
    public override int Points { get; set; } = 5;
    public override Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    public override Rectangle Bounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    public Tank(Vector2 position)
    {
        _position = position;
        Sprites = new Rectangle[SpriteFrames.Aliens];
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Tank");

        var w = SpriteSize.Aliens["width"];
        var h = SpriteSize.Aliens["height"];

        Sprites[0] = new(0, 0, w, h);
        Sprites[1] = new(w, 0, w, h);
    }

    public override void Update(GameTime gameTime)
    {
        ElapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        var x = (int)_position.X;
        var y = (int)_position.Y;
        var w = Sprites[SpriteIdx].Width;
        var h = Sprites[SpriteIdx].Height;

        Animation();

        _bounds = new(x, y, w, h);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, _position, Sprites[SpriteIdx], Color.White);
    }

    public override void HandleCollision()
    {
        IsAlive = false;
        ScoreManager.Increment(Points);
        SoundManager.PlaySoundEffect("invaderkilled");
        EntityManager.RemoveEntity(this);
    }
}
