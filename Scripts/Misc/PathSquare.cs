using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PathSquare : AnimatedSprite2D
{
	
	[Export] private Utils.Colors color;

	public override void _Process(double delta)
	{
		string colorIdStr = ((int)color).ToString();

		if (PathManager.Instance.Path.Contains(colorIdStr))
			Frame = TravelManager.Instance.CurrWorld == color ? 10 : 1;//(int)color + 9 : (int)color;
		else
			Frame = 0;
	}


}
