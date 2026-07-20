using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EscapeRoom_GameJam;

public class EscapeRoom : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private List<MovableObject> _movableObjects = new();

    public EscapeRoom()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _player = new Player(new Vector2(100, 100));
        _player.LoadContent(Content);
        
        // Spawn movable objects here!!!
        _movableObjects.Add(new MovableObject(new Vector2(300, 200), "Textures/BlueTempBox"));
        
        
        foreach (var obj in _movableObjects)
        {
            obj.LoadContent(Content);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        Vector2 moveDirection = Vector2.Zero;
        
        // Movement
        if (keyboardState.IsKeyDown(Keys.W)) moveDirection.Y -= 1;
        if (keyboardState.IsKeyDown(Keys.S)) moveDirection.Y += 1;
        if (keyboardState.IsKeyDown(Keys.A)) moveDirection.X -= 1;
        if (keyboardState.IsKeyDown(Keys.D)) moveDirection.X += 1;
        if (moveDirection != Vector2.Zero)
        {
            _player.Move(moveDirection, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        
        // Picking up
        if (keyboardState.IsKeyDown(Keys.Space)) _player.TryGrabObject(_movableObjects);
        if(_player.HeldObject != null) Console.WriteLine("Pusi kurac");

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        //////////////////
        
        _player.Draw(_spriteBatch);
        
        // Drawing movable objects
        foreach (var obj in _movableObjects)
        {
            obj.Draw(_spriteBatch);
        }
        
        //////////////////
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}