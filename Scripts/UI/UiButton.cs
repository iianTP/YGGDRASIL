using Godot;
using System;

public partial class UiButton : Button
{
	[Export] private Color mainColor = new Color(255,255,255);
	[Export] private Color hoverColor = new Color(255,255,0);

	public override void _Ready()
	{
		Modulate = mainColor;
	}

	public void _on_mouse_entered()
	{
		Modulate = hoverColor;
	}

	public void _on_mouse_exited()
	{
		Modulate = mainColor;
	}

}
