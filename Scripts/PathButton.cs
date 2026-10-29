using Godot;
using System;

public partial class PathButton : Area2D
{
	[Signal] public delegate void ButtonPressedEventHandler();

	[Export] private Timer buttonTimer;
	[Export] private AnimatedSprite2D as2d;
	[Export] private AnimatedSprite2D indicatorSprite;
	[Export] private AnimationPlayer ap;

	[Export] private Node2D pathDisplay;

	private bool inRange = false;

	public override void _Ready()
	{
		SetFrame();

		buttonTimer.Timeout += StopPressing;

		PathManager.Instance.SolutionAttempt += Indicate;
		PathManager.Instance.StartedSolution += Initiate;
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
		SetFrame();
	}

	private void StopPressing()
	{
		buttonTimer.Stop();
		as2d.Play("default");
	}
	private void SetFrame()
	{
		indicatorSprite.Frame = PathManager.Instance.Tracking ? 1 : 0;
	}

	private void Initiate()
	{
		ap.Play("RESET");
		pathDisplay.Show();	
	}
	private void Indicate(string animation)
	{
		pathDisplay.Hide();
		ap.Play(animation);
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

	public void _on_tree_exiting()
	{
		PathManager.Instance.SolutionAttempt -= Indicate;
		PathManager.Instance.StartedSolution -= Initiate;
	}
}
