using Godot;
using System;
using System.IO;

public partial class Letter : AnimatedSprite2D
{
	[Export] private Utils.Letters letter;

	public override void _Ready()
	{
		if (PathManager.Instance.SolvedIdList.Contains((int)letter))
		{
			DisplayLetter();
		}		
	}

	public void DisplayLetter()
	{
		Play(PathManager.Instance.SolvedSecretPuzzle() ? "show-pink" : "show");
		Frame = (int)letter;
	}

}
