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

    // Player stats:
    private Texture2D   _playerTexture;
    private Vector2     _playerPosition;
    private Vector2     _playerVelocity;
    private const float _playerJumpForce = -400;
    private Rectangle   _playerRect;

    // Obstacle stats:
    private Vector2   _obstaclePosition;
    private Vector2   _obstacleSize;
    private float     _obstacleSpeed = 125f;
    private Rectangle _obstacleRectTop;
    private Rectangle _obstacleRectBottom;
    private Rectangle _obstacleGap;

    // Fonts:
    private SpriteFont _drumnikFont;
    private Vector2 _scoreTextPosition = new Vector2(128, 128);
    private Vector2 _scoreTextOrigin;

    private Vector2 _screenSize;
    private float _gravity = 9.8f;
    private double _lastTime = 0;

    private int _score = 0;
    private bool _isInGame = true;

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
        _playerPosition = new Vector2(128, 256);
        _playerVelocity = Vector2.Zero;
        _playerRect = new Rectangle(
            (int)_playerPosition.X,
            (int)_playerPosition.Y,
            128,
            128);

        _obstacleSize = new Vector2(76, 128);
        _obstaclePosition = new Vector2(
            _graphics.PreferredBackBufferWidth - _obstacleSize.X,
            _graphics.PreferredBackBufferHeight / 2 - _obstacleSize.Y
        );
        _obstacleRectTop    = new Rectangle();
        _obstacleRectBottom = new Rectangle();

        _obstacleGap = new Rectangle(
            (int)(_screenSize.X / 2) - 128,
            (int)(_screenSize.Y / 2) - 128,
            256,
            256
        );

        _score = 0;
        _isInGame = true;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _playerTexture = Content.Load<Texture2D>(
            "SpriteSheets/spritesheet-enemies-double");
        _bgTexture     = Content.Load<Texture2D>(
            "SpriteSheets/background-mountain");
        _drumnikFont   = Content.Load<SpriteFont>(
            "Fonts/DrumnikFontDescription");
        _scoreTextOrigin = _drumnikFont.MeasureString($"Score: {_score}");

        _pixelTexture.SetData(new[] { Color.BurlyWood });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        double deltaTime = gameTime.TotalGameTime.TotalSeconds
            - _lastTime;

        if (_isInGame)
        {
            _playerVelocity.Y += _gravity * (float)deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _playerVelocity.Y = _playerJumpForce * (float)deltaTime;
            }

            _playerPosition.Y += _playerVelocity.Y;
            _playerRect.Location = _playerPosition.ToPoint();

            _obstaclePosition.X -= _obstacleSpeed * (float)deltaTime;
            if (_obstaclePosition.X <= (-_obstacleSize.X - 27))
            {
                _obstaclePosition.X = _graphics.PreferredBackBufferWidth;
                _score++;
            }
            _obstacleGap.Location = _obstaclePosition.ToPoint();
            _obstacleRectTop.Location = new Point(
                (int)_obstaclePosition.X,
                0);
            _obstacleRectTop.Width =  _obstacleGap.Width;
            _obstacleRectTop.Height = _obstacleGap.Location.Y;

            _obstacleRectBottom.Location = new Point(
                (int)_obstaclePosition.X,
                (int)_screenSize.Y - _obstacleGap.Location.Y);
            _obstacleRectBottom.Width =  _obstacleGap.Width;
            _obstacleRectBottom.Height = (int)_screenSize.Y
                - _obstacleGap.Location.Y
                - _obstacleGap.Height;

            bool isPlayerColliding = _obstacleRectTop.Intersects(_playerRect)
                || _obstacleRectBottom.Intersects(_playerRect);
            if (isPlayerColliding)
            {
                _isInGame = false;
            }

            bool isOutOfScreen = (_playerRect.Bottom >= _screenSize.Y)
                || (_playerRect.Right >= _screenSize.X)
                || (_playerRect.Top <= 0)
                || (_playerRect.Left <= 0);
            if (isOutOfScreen)
                _isInGame = false;

        }

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

        if (_isInGame)
        {
            _spriteBatch.Draw(
                _playerTexture,
                _playerRect,
                new Rectangle(256, 256, 128, 128),
                Color.White);

            _spriteBatch.Draw(
                _pixelTexture,
                _obstacleRectTop,
                Color.IndianRed);
            _spriteBatch.Draw(
                _pixelTexture,
                _obstacleRectBottom,
                Color.IndianRed);

            _spriteBatch.DrawString(
                _drumnikFont,
                $"Score: {_score}",
                _scoreTextPosition,
                Color.White,
                0,
                _scoreTextOrigin,
                1,
                SpriteEffects.None,
                0);
        }
        else
        {
            _scoreTextPosition = _screenSize * 0.5f + _scoreTextOrigin;
            _spriteBatch.DrawString(
                _drumnikFont,
                $"Score: {_score}",
                _scoreTextPosition,
                Color.White,
                0,
                _scoreTextOrigin,
                2,
                SpriteEffects.None,
                0);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
