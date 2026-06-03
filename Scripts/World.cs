using Godot;
using System;

public partial class World : Node2D
{
	private PathManager pm;

	[Export] private Player player;
	[Export] private Portal[] portals;
	[Export] private Color backgroundColor;
	[Export] private int id;

	public override void _Ready()
	{
		pm = PathManager.Instance;

		RenderingServer.SetDefaultClearColor(backgroundColor);
		pm.AppendPath(id);
	}

	public void PositionPlayer(Utils.Directions arrivalPortal)
	{
		foreach (Portal p in portals)
		{
			if (p.GetDirection() == arrivalPortal)
			{
				player.GlobalPosition = p.GlobalPosition;
				p.active = false;
				break;
			}
		}
	}

	public void _on_button_button_pressed()
	{
		pm.UpdatePathTrackingState();
		pm.AppendPath(id);
	}

}
