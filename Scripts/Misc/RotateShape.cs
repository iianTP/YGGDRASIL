using Godot;
using System;

public partial class RotateShape : CsgCombiner3D
{
	[Export] private int speed;

	public override void _Process(double delta)
	{
		Rotate(Vector3.Up, speed * (float)delta);
	}

}
