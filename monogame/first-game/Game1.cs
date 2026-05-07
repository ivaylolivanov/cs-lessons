using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _squareTexture;
    private Vector2 _screenSize;
    private float _ground;
    private float _jumpTimer;

    private Texture2D _background;

    private Player _player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _screenSize = new Vector2(1280, 720);
        _graphics.PreferredBackBufferWidth  = (int)_screenSize.X;
        _graphics.PreferredBackBufferHeight = (int)_screenSize.Y;
    }

    protected override void Initialize()
    {
        _jumpTimer = 0;
        _ground = _screenSize.Y;

        _player = new Player(
            new Vector2(50, 335),
            new Vector2(40, 65)
        );

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

        if (gamePad.Buttons.Back == ButtonState.Pressed
            || keyboard.IsKeyDown(Keys.Escape))
            Exit();

        Vector2 direction = new Vector2();
        if (keyboard.IsKeyDown(Keys.A))
        {
            direction.X = -1;
        }

        if (keyboard.IsKeyDown(Keys.D))
        {
            direction.X = 1;
        }

        if (keyboard.IsKeyDown(Keys.Space)
            && (_jumpTimer <= 0))
        {
            direction.Y = -100;
            _jumpTimer = 1;
        }

        if (_jumpTimer >= 0)
            _jumpTimer -= deltaTime;

        _player.Update(deltaTime);
        _player.SetDirection(direction);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(
            _background, Vector2.Zero, Color.White);

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
}
