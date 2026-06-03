using Godot;
using System;

public partial class SolutionMap : Node2D
{
	public override void _Ready()
	{
		CollapseColorPads();
	}

	private void CollapseColorPads()
	{
		foreach (string color in PathManager.Instance.SolvedList)
		{
			Node pad = GetNodeOrNull<ColorRect>(color);
			pad?.CallDeferred("free");
		}
	}

}
