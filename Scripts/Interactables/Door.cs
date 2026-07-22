using Godot;
using System;

public partial class Door : Interactable
{
	[Export] private Vignette vignette;
	private Vector2 solvedCoords = new Vector2(373,340);

	public override void _Ready()
	{
		if (PathManager.Instance.SolvedSecretPuzzle())
			GlobalPosition = solvedCoords;
	}

	private void GoToPinkWorld()
	{
		AudioManager.Instance.PlaySecretTrack();
		GetTree().ChangeSceneToFile("res://Scenes/Worlds/pink.tscn");
	}

	protected override void Action()
	{
		AudioManager.Instance.StopMusic();
		vignette.SetWhite(0);
		vignette.Transition(1,1,4,5,GoToPinkWorld);
	}

	public override void _on_area_exited(Area2D area)
	{
		// throw new NotImplementedException();
	}

}
