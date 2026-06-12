using Godot;
using System;

public partial class Controls : RichTextLabel
{
	public void _on_play_mouse_entered()
	{
		Show();    
	}

	public void _on_play_mouse_exited()
	{
		Hide();
	}
}
