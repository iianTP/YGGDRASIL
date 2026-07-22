using Godot;
using System;

public partial class Pause : Control
{

	[Export] private Button resume;
	[Export] private Button exit;

	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
		resume.Text = Tr("BT_RESUME");
		exit.Text = Tr("BT_EXIT");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("pause"))
		{
			Utils.Instance.UpdateRichPresence("update_details", "Paused");
			GetTree().Paused = true;
			Show();
		}
	}

	public void _on_resume_pressed()
	{
		Hide();
		GetTree().Paused = false;
		Utils.Instance.UpdateRichPresence("update_details", "Wandering...");
	}

	public void _on_exit_pressed()
	{
		GetTree().Paused = false;
		AudioManager.Instance.StopSecretTrack();
		AudioManager.Instance.StopMusic();
		GetTree().ChangeSceneToFile("res://Scenes/UI/menu.tscn");
	}
	
}
