using Godot;
using System;

public partial class Keybind : Control
{
	[Export] private string keybindName;
	[Export] private string keybindAction;
	[Export] private UiButton button;

	public override void _Ready()
	{
		if (InputMap.ActionGetEvents(keybindAction)[0] is InputEventKey iek)
			button.Text = keybindName + ": " + iek.AsText();
	}

}
