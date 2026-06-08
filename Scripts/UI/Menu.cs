using Godot;
using System;

public partial class Menu : CanvasLayer
{
	[Export] private PackedScene initWorld;

	public void _on_play_pressed()
	{
		Node world = initWorld.Instantiate();
		GetTree().ChangeSceneToNode(world);
	}

	public void _on_config_pressed()
	{
		
	}

	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
