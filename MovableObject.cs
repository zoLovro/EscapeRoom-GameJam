using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EscapeRoom_GameJam;

public class MovableObject
{
    public Vector2 Position { get; set; }
    public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
    
    private Texture2D _texture;
    private string _textureName;

    public MovableObject(Vector2 startingPosition, string textureName)
    {
        Position = startingPosition;
        _textureName = textureName;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>(_textureName);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.White);
    }
}