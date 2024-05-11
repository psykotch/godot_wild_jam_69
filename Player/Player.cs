using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public float maxSpeed = 400;
    [Export]
    public float accel = 1500;
    [Export]
    public float friction = 600;

    private Vector2 playerInput = Vector2.Zero; 

    private Vector2 getInput()
    {
        Vector2 input = Vector2.Zero;

        if (Input.IsActionPressed("ui_right"))
            input.X++;
        if (Input.IsActionPressed("ui_left"))
            input.X--;
        if (Input.IsActionPressed("ui_up"))
            input.Y--;
        if (Input.IsActionPressed("ui_down"))
            input.Y++;
        return input.Normalized();
    }

    public void playerMovement(double delta)
    {
        playerInput = getInput();

        /* Case when there's no input and the player stops */
        if (playerInput == Vector2.Zero)
        {
            if (Velocity.Length() > (friction * delta)) /* then we decelerate for the next frame */
                Velocity -= Velocity.Normalized() * (friction * (float)(delta));
            else /* then we stop completely */
                Velocity = Vector2.Zero;
        }
        /* case when player moves */
        else
        {
            Velocity += (playerInput * accel * (float)delta);
            Velocity = Velocity.LimitLength(maxSpeed);
        }
        MoveAndSlide();
    }
    public override void _PhysicsProcess(double delta)
	{
        playerMovement(delta);
	}
}
