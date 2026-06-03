using Godot;
using System;

public partial class Teleport : Node2D
{
	[Export] private TeleportPoint tpEnter;
	[Export] private TeleportPoint tpExit;


	public void _on_teleport_enter_area_entered(Area2D area)
	{
		if (tpEnter.active)
		{
			tpExit.active = false;
			Player player = (Player)area.GetParent();
			player.GlobalPosition = tpExit.GlobalPosition;
		}
	}

	public void _on_teleport_exit_area_entered(Area2D area)
	{
		if (tpExit.active)
		{
			tpEnter.active = false;
			Player player = (Player)area.GetParent();
			player.GlobalPosition = tpEnter.GlobalPosition;
		}
	}
	
}
