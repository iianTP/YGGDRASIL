using Godot;
using System;

public partial class ShapeSetup : SubViewport
{
	[Export] private PackedScene[] shapes;

	public override void _Ready()
	{
		int randIndex = Utils.Instance.rng.Next(0,4);
		Node shape = shapes[randIndex].Instantiate();
		AddChild(shape);
	}

}
