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

    private Texture2D _background;

    private Player _player;

    private Rectangle[] _platforms;
    private Enemy[] _enemies;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _screenSize = new Vector2(1280, 720);
        _graphics.PreferredBackBufferWidth  = (int)_screenSize.X;
        _graphics.PreferredBackBufferHeight = (int)_screenSize.Y;

        _platforms = new Rectangle[5];
        _platforms[0] = new Rectangle(50, 600, 275, 40);
        _platforms[1] = new Rectangle(150, 450, 275, 40);
        _platforms[2] = new Rectangle(350, 300, 275, 40);
        _platforms[3] = new Rectangle(675, 250, 55, 400);
        _platforms[4] = new Rectangle(1000, 450, 150, 75);

        _enemies = new Enemy[3];
    }

    protected override void Initialize()
    {
        _ground = _screenSize.Y;

        _player = new Player(
            new Vector2(50, 335),
            new Vector2(60, 75)
        );

        _enemies[0] = new Enemy(
            new Vector2(500, 335),
            new Vector2(100, 100)
        );

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("Images/background");

        _squareTexture = new Texture2D(GraphicsDevice, 1, 1);
        _squareTexture.SetData(new[] { Color.Beige });

        Texture2D playerTexture = Content.Load<Texture2D>("Images/main-character");
        _player.LoadContent(playerTexture);

        Texture2D enemyTexture = Content.Load<Texture2D>("Images/goofy-goblin");
        _enemies[0].LoadContent(enemyTexture);
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

        if (keyboard.IsKeyDown(Keys.Space) && (_player.Velocity.Y == 0))
        {
            _player.Jump();
        }

        _player.Update(deltaTime);
        _player.SetDirection(direction);

        _enemies[0].Update(deltaTime, _player);

        ResolveCollisions();

        if ((_player.Position.Y + _player.Size.Y) >= _ground)
        {
            _player.Velocity.Y = 0;
            _player.Position.Y = _ground - _player.Size.Y;
        }

        if ((_enemies[0].Position.Y + _enemies[0].Size.Y) >= _ground)
        {
            _enemies[0].Velocity.Y = 0;
            _enemies[0].Position.Y = _ground - _enemies[0].Size.Y;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(
            _background, Vector2.Zero, Color.White);

        for (int i = 0; i < _platforms.Length; ++i)
        {
            _spriteBatch.Draw(
                _squareTexture,
                _platforms[i],
                Color.RosyBrown);
        }

        _enemies[0].Draw(_spriteBatch);
        _player.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void ResolveCollisions()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            Vector2 collisionData = GetCollisionData(_player.Collider, _platforms[i]);
            if (collisionData == Vector2.Zero)
                continue;

            _player.Position += collisionData;
            if (collisionData.X != 0)
            {
                _player.Velocity.X = 0;
            }
            else
            {
                if (collisionData.Y < 0)
                {
                    _player.Velocity.Y = 0;
                }
                else
                {
                    _player.Velocity.Y = 0.1f;
                }
            }
        }
    }

    private Vector2 GetCollisionData(Rectangle a, Rectangle b)
    {
        Vector2 result = Vector2.Zero;

        if (a.Intersects(b))
        {
            Rectangle overlap = Rectangle.Intersect(a, b);
            if (overlap.Width < overlap.Height)
            {
                int direction = a.Center.X < b.Center.X ? -overlap.Width : overlap.Width;
                result.X = direction;
            }
            else
            {
                int direction = a.Center.Y < b.Center.Y ? -overlap.Height : overlap.Height;
                result.Y = direction;
            }
        }

        return result;
    }

    // NOTE: Meant as an example
    private void ResolveCollisionsManual()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            float left   = (_player.Position.X + _player.Size.X) - _platforms[i].Left;
            float top    = (_player.Position.Y + _player.Size.Y) - _platforms[i].Top;
            float right  = _platforms[i].Right  - _player.Position.X;
            float bottom = _platforms[i].Bottom - _player.Position.Y;

            bool hasCollided = (left > 0)
                && (right < 0)
                && (top > 0)
                && (bottom < 0);
            if (hasCollided)
            {
                float minOverlap = System.Math.Min(
                    System.Math.Min(left, right),
                    System.Math.Min(top, bottom));

                if (minOverlap == left)
                {
                    _player.Position.X -= left;
                    _player.Velocity.X = 0;
                }
                else if (minOverlap == right)
                {
                    _player.Position.X += right;
                    _player.Velocity.X = 0;
                }
                else if (minOverlap == top)
                {
                    _player.Position.Y -= top;
                    _player.Velocity.Y = 0;
                }
                else
                {
                    _player.Position.Y += bottom;
                    _player.Velocity.Y *= -1;
                }
            }
        }
    }
}
