using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Color _bgColor;

    private Texture2D _pixelTexture;
    private Vector2 _playerPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _bgColor = Color.Orange;
        _pixelTexture =
            new Texture2D(_graphics.GraphicsDevice, 1, 1);
        _playerPosition = new Vector2(0, 0);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pixelTexture.SetData(new[] { Color.BurlyWood });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _playerPosition.Y++;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_bgColor);

        _spriteBatch.Begin();

        Rectangle playerRect = new Rectangle(
            (int)_playerPosition.X,
            (int)_playerPosition.Y,
            20,
            20);
        _spriteBatch.Draw(_pixelTexture, playerRect, Color.AliceBlue);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
