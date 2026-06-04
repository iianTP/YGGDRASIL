using Godot;
using System;

public partial class OldGuy : DialogEntity
{
	protected override void Action()
	{
		if (PathManager.Instance.SolvedAllPuzzles())
			dialogue = ["Yes, the exit is sealed. Why do you think I'm still here?"];

		base.Action();
	}

}
