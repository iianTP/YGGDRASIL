using Godot;
using System;

public abstract partial class Interactable : Area2D
{
	protected abstract void Action();

	public void _on_area_entered(Area2D area)
	{
		if (area.IsInGroup("Player"))
			Action();
	}

	public abstract void _on_area_exited(Area2D area);
}
