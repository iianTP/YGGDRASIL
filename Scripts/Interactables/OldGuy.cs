using Godot;
using System;

public partial class OldGuy : DialogEntity
{

	public override void _Ready()
	{
		if (PathManager.Instance.SolvedSecretPuzzle() && Owner.Name == "Gray")
			CallDeferred("free");
	}

	protected override void Action()
	{
		if (PathManager.Instance.SolvedAllPuzzles())
			dialogue = [Tr("OLDGUY_3")];

		if (PathManager.Instance.SolvedSecretPuzzle())
			dialogue = [Tr("OLDGUY_4"),Tr("OLDGUY_5")];
		
		base.Action();
	}

}
