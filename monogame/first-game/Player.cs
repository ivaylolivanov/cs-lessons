using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game;

public class Player
{
    private const float _gravity = 980;
    private const float _movementSpeed = 300;
    private const float _jumpForce = 500;

    public Vector2 Position;
    public Vector2 Size;

    private Vector2 _velocity;

    public Player(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;

        _velocity = Vector2.Zero;
    }

    public void Update(float dt)
    {
        if (Position.Y < (Game1.Ground - Size.Y))
        {
            _velocity.Y += _gravity * dt;
        }
        else if (_velocity.Y > 0)
        {
            Position.Y = Game1.Ground - Size.Y;
            _velocity.Y = 0;
        }

        Position.X += _velocity.X * _movementSpeed * dt;
        Position.Y += _velocity.Y * dt;
    }

    public void Draw()
    {
    }

    public void Jump()
    {
        if (_velocity.Y == 0)
        {
            _velocity.Y -= _jumpForce;
        }
    }

    public void SetDirection(float direction)
    {
        _velocity.X = direction;
    }
}
