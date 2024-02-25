using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRetro.Interfaces;
using SpaceInvadersRetro.Utils;

namespace SpaceInvadersRetro.Components;
public class Barricade : EntityBase
{

    private Rectangle[] _sprite;
    private Vector2 _position;
    private Rectangle _bounds;
    private Texture2D _texture;
    private int _lifes = 4;
    private int _hits = 0;
    
    public Barricade(Vector2 position)
    {
        _position = position;
    }

    public override Rectangle Bounds { get => _bounds; set => _bounds = value; }

    public override void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Sprites/Barricade");

        var w = SPRITE_SIZE.BARRICADE["width"];
        var h = SPRITE_SIZE.BARRICADE["height"];

        _sprite[3] = new(0, h-115, w, 39);
        _sprite[2] = new(0, h-76, w, 38);
        _sprite[1] = new(0, h-38, w, 25);
        _sprite[0] = new(0, h-13, w, 13);

    }
    public override void Update(GameTime gameTime)
    {

        _bounds = new();

        if(_lifes <=0 )
        {
            EntityManager.RemoveEntity(this);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, _sprite[_lifes-1], Color.White);
    }

    public override void HandleCollision()
    {
        _hits++;
        if(_hits > 3)
        {
            _lifes--;
            _hits = 0;
        
        }

        RemoveBarricade(_lifes);
    }

    private void RemoveBarricade(int lifes){
        
        if(lifes <= 0 ){
            EntityManager.RemoveEntity(this);
        }

    }




}