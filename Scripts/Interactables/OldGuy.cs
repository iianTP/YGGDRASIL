using Godot;
using System;

public partial class OldGuy : DialogEntity
{
	protected override void Action()
	{
		if (PathManager.Instance.SolvedAllPuzzles())
			dialogue = [Tr("OLDGUY_3")];

		base.Action();
	}

}
