using Godot;
using System;

public partial class Trailer : CanvasLayer
{
	[Export] private Letter[] letters;
	[Export] private RichTextLabel outNow;

	[Export] private Timer logoTimer;
	[Export] private Timer outNowTimer;

	public override void _Ready()
	{
		logoTimer.Timeout += ShowLogo;
		outNowTimer.Timeout += ShowOutNow;
		logoTimer.Start();
	}

	private void ShowLogo()
	{
		foreach (Letter letter in letters)
		{
			letter.DisplayLetter();
		}
		outNowTimer.Start();
	}

	private void ShowOutNow()
	{
		outNow.Show();
	}

}
