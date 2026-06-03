using Godot;
using System;

public partial class OldGuy : DialogEntity
{
	public override void _Ready()
	{
		SetDialogue();
	}

	private void SetDialogue()
	{
		dialogue = [
			"Buttons... The very start and the end of it all.",
			"'X' marks the pirate, said the spots."
		];

		if (PathManager.Instance.SolvedAllPuzzles())
			dialogue = ["Yes, the exit is sealed. Why do you think I'm still here?"];
	}

}
