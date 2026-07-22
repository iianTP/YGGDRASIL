using Godot;
using System;

public partial class MenuPortal : Interactable
{

	public override void _on_area_exited(Area2D area)
	{
		// throw new NotImplementedException();
	}

	protected override void Action()
	{
		Vignette.Instance.Transition(1,1,5,5,GoToMenu);
	}


	private void GoToMenu()
	{
		GetTree().ChangeSceneToFile("Scenes/UI/Menu.tscn");
	}
}
