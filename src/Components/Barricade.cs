using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;

public class Barricade : EntityBase
{
    private readonly Rectangle[] _sprites = new Rectangle[5];
    private readonly Vector2 _position;
    private Rectangle _bounds;
    private Texture2D _texture;
    private int _spriteIdx = 4;
    private int _lifes = 4;
    private int _hits;
    private bool _isDead;

    public Barricade(Vector2 position)
    {
        _position = position;

        _isDead = _lifes == 0;

        var w = SPRITE_SIZE.BARRICADE["width"];
        var h = SPRITE_SIZE.BARRICADE["height"];

        _sprites[4] = new Rectangle(0, h - 115, w, 39);
        _sprites[3] = new Rectangle(0, h - 76, w, 38);
        _sprites[2] = new Rectangle(0, h - 38, w, 25);
        _sprites[1] = new Rectangle(0, h - 13, w, 13);
        _sprites[0] = new Rectangle();
    }

    public override Rectangle Bounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    public override void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Sprites/Barricade");
    }

    public override void Update(GameTime gameTime)
    {
        var x = (int)_position.X;
        var y = (int)_position.Y;
        var w = _sprites[_spriteIdx].Width; // 3, 2, 1, 0
        var h = _sprites[_spriteIdx].Height; // 3, 2, 1, 0

        _bounds = new Rectangle(x, y, w, h);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, _sprites[_spriteIdx], Color.White);
    }

    public override void HandleCollision()
    {
        if (_isDead) EntityManager.RemoveEntity(this);

        _hits++;

        if (_hits < 1) return;
        _lifes--;
        _hits = 0;
        if(_spriteIdx >= 0) _spriteIdx--;
    }
}
