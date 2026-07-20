using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EscapeRoom_GameJam;

public class Player
{
    private int _movementSpeed = 300;
    private Vector2 _position;
    private Texture2D _texture;
    private Vector2 _textureDimensions;
    private MovableObject _heldObject = null;

    public MovableObject HeldObject
    {
        get => _heldObject;
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    public Vector2 TextureDimensions
    {
        get => _textureDimensions;
    }

    public Player(Vector2 startingPosition)
    {
        _position = startingPosition;
    }
    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Textures/PlayerImageTemp");
        _textureDimensions = new Vector2(_texture.Width, _texture.Height);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }

    public void Move(Vector2 direction, float deltaTime)
    {
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }
        _position += direction * _movementSpeed * deltaTime;
    }

    public void TryGrabObject(List<MovableObject> objects)
    {
        Rectangle playerBounds = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);

        foreach (var obj in objects)
        {
            if (playerBounds.Intersects(obj.Bounds))
            {
                _heldObject = obj;
                break;
            }
        }
    }
}