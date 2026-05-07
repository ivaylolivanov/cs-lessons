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

    public Vector2 Velocity;

    public Player(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;

        Velocity = Vector2.Zero;
    }

    public void Update(float dt)
    {
        Velocity.Y += _gravity * dt;
        Position.X += Velocity.X * _movementSpeed * dt;
        Position.Y += Velocity.Y * dt;
    }

    public void Draw()
    {
    }

    public void Jump()
    {
        if (Velocity.Y == 0)
        {
            Velocity.Y -= _jumpForce;
        }
    }

    public void SetDirection(float direction)
    {
        Velocity.X = direction;
    }
}
