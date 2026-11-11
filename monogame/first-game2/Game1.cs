using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _pixelTexture;
    private Texture2D _bgTexture;

    private Texture2D _playerTexture;
    private Vector2 _playerPosition;
    private Vector2 _playerVelocity;

    private Vector2 _obstaclePosition;
    private Vector2 _obstacleSize;

    private Vector2 _screenSize;
    private float _gravity = 9.8f;
    private double _lastTime = 0;
    private const float _playerJumpForce = -400;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _screenSize = new Vector2(1280, 720);
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth  = (int)_screenSize.X;
        _graphics.PreferredBackBufferHeight = (int)_screenSize.Y;
        _graphics.ApplyChanges();

        _pixelTexture =
            new Texture2D(_graphics.GraphicsDevice, 1, 1);
        _playerPosition = new Vector2(0, 0);
        _playerVelocity = Vector2.Zero;

        _obstacleSize = new Vector2(76, 128);
        _obstaclePosition = new Vector2(
            _graphics.PreferredBackBufferWidth  - _obstacleSize.X,
            0
        );

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _playerTexture = Content.Load<Texture2D>(
            "SpriteSheets/spritesheet-enemies-double");
        _bgTexture     = Content.Load<Texture2D>(
            "SpriteSheets/background-mountain");

        _pixelTexture.SetData(new[] { Color.BurlyWood });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        double deltaTime = gameTime.TotalGameTime.TotalSeconds
            - _lastTime;

        _playerVelocity.Y += _gravity * (float)deltaTime;
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            _playerVelocity.Y = _playerJumpForce * (float)deltaTime;
        }

        _playerPosition.Y += _playerVelocity.Y;

        --_obstaclePosition.X;

        if (_obstaclePosition.X <= 0)
            _obstaclePosition.X = _graphics.PreferredBackBufferWidth
                - _obstacleSize.X;

        base.Update(gameTime);
        _lastTime = gameTime.TotalGameTime.TotalSeconds;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        Rectangle _bgRectangle = new Rectangle(
            0,
            0,
            (int)_screenSize.X,
            (int)_screenSize.Y);
        _spriteBatch.Draw(
            _bgTexture,
            _bgRectangle,
            Color.White
        );

        Rectangle playerRect = new Rectangle(
            (int)_playerPosition.X,
            (int)_playerPosition.Y,
            128,
            128);
        _spriteBatch.Draw(
            _playerTexture,
            playerRect,
            new Rectangle(256, 256, 128, 128),
            Color.White);

        Rectangle obstacleRect = new Rectangle(
            (int)_obstaclePosition.X,
            (int)_obstaclePosition.Y,
            (int)_obstacleSize.X,
            (int)_obstacleSize.Y);
        _spriteBatch.Draw(_pixelTexture, obstacleRect, Color.IndianRed);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
