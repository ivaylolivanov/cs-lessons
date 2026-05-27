using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy
{
    private const float _gravity = 9.8f;
    private const float _jumpForce = 450f;

    private float _movementSpeed;
    private Texture2D _texture;

    public Vector2 Position;
    public Rectangle Collider;
    public Vector2 Size;

    public Vector2 Velocity;

    public Enemy(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;

        _movementSpeed = 300;
        Collider = new Rectangle(Position.ToPoint(), Size.ToPoint());
    }

    public void LoadContent(Texture2D texture)
    {
        _texture = texture;
    }

    public void Update(float dt, Player player)
    {
        Velocity.Y += _gravity;

        Vector2 direction = (player.Collider.Center - Collider.Center).ToVector2();
        float absHorizontalDiff = System.Math.Abs(direction.X);
        float absVerticalDiff = System.Math.Abs(direction.Y);
        if (absVerticalDiff > 25)
            return;

        if (absHorizontalDiff > 500)
            return;

        direction.Normalize();
        Velocity.X = direction.X;

        Position.X += Velocity.X * _movementSpeed * dt;
        Position.Y += Velocity.Y * dt;

        Collider.X = (int)Position.X;
        Collider.Y = (int)Position.Y;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Collider, Color.White);
    }

}
