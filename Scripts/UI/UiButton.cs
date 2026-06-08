using Godot;
using System;

public partial class UiButton : Button
{
	public void _on_mouse_entered()
	{
		Color currColor = Modulate;
		currColor.B = 0;
		Modulate = currColor;
	}

	public void _on_mouse_exited()
	{
		Color currColor = Modulate;
		currColor.B = 255;
		Modulate = currColor;
	}

}
