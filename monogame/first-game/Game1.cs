using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game;

public class Game1 : Game
{
    public static float Ground = 720;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _squareTexture;
    private Vector2 _screenSize = new Vector2(1280, Ground);

    private Texture2D _background;

    private Player _player;
    private Rectangle[] _platforms;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth  = (int)_screenSize.X;
        _graphics.PreferredBackBufferHeight = (int)_screenSize.Y;
    }

    protected override void Initialize()
    {
        _player = new Player(
            new Vector2(50, 335),
            new Vector2(40, 65)
        );

        _platforms = new[]
        {
            new Rectangle(200, 600, 200, 20),
            new Rectangle(400, 480, 200, 20),
        };

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("Images/background");

        _squareTexture = new Texture2D(GraphicsDevice, 1, 1);
        _squareTexture.SetData(new[] { Color.Beige });
    }

    protected override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
        KeyboardState keyboard = Keyboard.GetState();

        bool isBackPressed = (gamePad.Buttons.Back == ButtonState.Pressed)
            || keyboard.IsKeyDown(Keys.Escape);
        if (isBackPressed)
            Exit();

        float direction = 0f;
        if (keyboard.IsKeyDown(Keys.A))
        {
            direction = -1;
        }

        if (keyboard.IsKeyDown(Keys.D))
        {
            direction = 1;
        }

        if (keyboard.IsKeyDown(Keys.Space))
        {
            _player.Jump();
        }

        _player.SetDirection(direction);
        _player.Update(deltaTime);
        ResolveCollisions();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(
            _background, Vector2.Zero, Color.White);

        foreach (var p in _platforms)
            _spriteBatch.Draw(_squareTexture, p, Color.Brown);

        _spriteBatch.Draw(
            _squareTexture,
            new Rectangle(
                (int)_player.Position.X,
                (int)_player.Position.Y,
                (int)_player.Size.X,
                (int)_player.Size.Y),
            Color.Beige);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void ResolveCollisions()
    {
        if (_player.Position.Y + _player.Size.Y >= Ground)
        {
            _player.Position.Y = Ground - _player.Size.Y;
            _player.Velocity.Y = 0;
        }

        foreach (var p in _platforms)
        {
            bool withinX = _player.Position.X + _player.Size.X > p.Left
                        && _player.Position.X < p.Right;
            bool crossedTop = _player.Velocity.Y > 0
                           && _player.Position.Y + _player.Size.Y >= p.Top
                           && _player.Position.Y + _player.Size.Y <= p.Bottom;

            if (withinX && crossedTop)
            {
                _player.Position.Y = p.Top - _player.Size.Y;
                _player.Velocity.Y = 0;
            }
        }
    }
}
