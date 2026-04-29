using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game;

public class Player
{
    private const float _gravity = 980;
    private const float _movementSpeed = 300;
    private const float _jumpForce = 600;
    private const float _jumpTime = 0.5f;

    public Vector2 Position;
    public Vector2 Size;

    private Vector2 _velocity;
    private float _jumpTimer = 0;

    public Player(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;

        _velocity = Vector2.Zero;
        _jumpTimer = 0;
    }

    public void Update(float dt)
    {
        if (_jumpTimer > 0)
            _jumpTimer -= dt;

        if (Position.Y < (Game1.Ground - Size.Y))
            _velocity.Y += _gravity * dt;
        else
            Position.Y = Game1.Ground - Size.Y;

        Position.X += _velocity.X * _movementSpeed * dt;
        Position.Y += _velocity.Y * dt;
    }

    public void Draw()
    {
    }

    public void Jump()
    {
        if (_jumpTimer <= 0f)
        {
            _velocity.Y -= _jumpForce;
            _jumpTimer = _jumpTime;
        }
    }

    public void SetDirection(float direction)
    {
        _velocity.X = direction;
    }
}
