using Godot;
using System;
using System.ComponentModel;

public partial class Player : CharacterBody2D
{

	[Export] private AnimatedSprite2D as2d;

	[Export] private int speed;
	[Export] private int jump_force;
	[Export] private float maxFallSpeed;

	private string currWorld;

	public override void _Ready()
	{
		currWorld = GetTree().CurrentScene.Name;
		as2d.Play($"{currWorld}_idle");
	}

	
	public override void _Process(double delta)
	{
		UpdateSprite();
	}

	public override void _PhysicsProcess(double delta)
	{

		if (!IsOnFloor())
		{
			Velocity += Vector2.Down * GetGravity() * (float)delta;
			if (Velocity.Y >= maxFallSpeed)
				Velocity = Vector2.Down * maxFallSpeed;
		}

		else if (Input.IsActionJustPressed("jump"))
			Velocity = Vector2.Up * jump_force;

		float move = Input.GetAxis("left","right");
		Velocity = new Vector2(move * speed, Velocity.Y);
		MoveAndSlide();
	}

	private void UpdateSprite()
	{
		if (Velocity.X != 0)
		{
			as2d.Play($"{currWorld}_walk");
			as2d.FlipH = Velocity.X < 0;
			return;
		}

		as2d.Play($"{currWorld}_idle");
		
	}
}
