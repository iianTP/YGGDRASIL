using Godot;
using System;
using System.IO;

public partial class ColorPad : ColorRect
{
	[Export] private int id;

	public override void _Ready()
	{
		if (PathManager.Instance.SolvedIdList.Contains(id))
			CallDeferred("free");
	}

}
