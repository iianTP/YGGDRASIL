using Godot;
using System;

public partial class TeleportPoint : Area2D
{
	[Export] private Sprite2D sprite2D;
	[Export] private CompressedTexture2D sprite;

	public bool active = true;

	public override void _Ready()
	{
		sprite2D.Texture = sprite;
	}

	public void _on_area_entered(Area2D area)
	{
		Player player = (Player)area.GetParent();
		player.Velocity = Vector2.Zero;
	}

	public void _on_area_exited(Area2D area)
	{
		active = true;
	}

}
