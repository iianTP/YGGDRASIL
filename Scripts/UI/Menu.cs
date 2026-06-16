using Godot;
using System;

public partial class Menu : CanvasLayer
{
	[Export] private PackedScene initWorld;

	[Export] private Button play;
	[Export] private Button quit;
	[Export] private Controls controls;

	public override void _Ready()
	{
		play.Text = Tr("BT_PLAY");
		quit.Text = Tr("BT_QUIT");
		controls.Text = Tr("CONTROLS");
	}

	public void _on_play_pressed()
	{
		Node world = initWorld.Instantiate();
		AudioManager.Instance.StartMusic();
		GetTree().ChangeSceneToNode(world);
	}

	public void _on_config_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/UI/config.tscn");
	}

	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
