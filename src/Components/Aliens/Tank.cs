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
    public override int Points { get; set; } = 10;
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
        _sprites = new Rectangle[SPRITE_FRAMES.ALIENS];
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("Sprites/Aliens/Tank");

        var w = SPRITE_SIZE.ALIENS["width"];
        var h = SPRITE_SIZE.ALIENS["height"];

        _sprites[0] = new(0, 0, w, h);
        _sprites[1] = new(w, 0, w, h);
    }

    public override void Update(GameTime gameTime)
    {
        _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        var x = (int)_position.X;
        var y = (int)_position.Y;
        var w = _sprites[_spriteIdx].Width;
        var h = _sprites[_spriteIdx].Height;

        Animation();

        _bounds = new(x, y, w, h);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, _position, _sprites[_spriteIdx], Color.White);
    }

    public override void HandleCollision()
    {
        IsAlive = false;
        ScoreManager.Increment(Points);
        EntityManager.RemoveEntity(this);
    }
}
