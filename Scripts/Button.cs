using Godot;
using System;

public partial class Button : Area2D
{
	[Signal] public delegate void ButtonPressedEventHandler();

	[Export] private Timer buttonTimer;
	[Export] private AnimatedSprite2D as2d;
	private bool inRange = false;

	public override void _Ready()
	{
		buttonTimer.Timeout += StopPressing;
	}

	public override void _Process(double delta)
	{
		if (inRange && Input.IsActionJustPressed("interact") && buttonTimer.IsStopped())
			PressButton();
	}


	private void PressButton()
	{
		buttonTimer.Start();
		as2d.Play("pressed");
		EmitSignal(SignalName.ButtonPressed);
	}

	private void StopPressing()
	{
		buttonTimer.Stop();
		as2d.Play("default");
	}

	public void _on_area_entered(Area2D area)
	{
		if (area.IsInGroup("Player"))
			inRange = true;
	}

	public void _on_area_exited(Area2D area)
	{
		if (area.IsInGroup("Player"))
			inRange = false;
	}
}
