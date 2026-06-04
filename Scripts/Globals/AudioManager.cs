using Godot;
using System;

public partial class AudioManager : Node
{
	public static AudioManager Instance { get; private set; }

	[Export] private AudioStreamPlayer2D success;
	[Export] private AudioStreamPlayer2D fail;
	[Export] private AudioStreamPlayer2D click;

	[Export] private AudioStreamPlayer2D[] tracks;
	private int currTrack = 0;

	public override void _Ready()
	{
		Instance = this;
		foreach (AudioStreamPlayer2D track in tracks)
		{
			track.Finished += NextTrack;
		}
		tracks[0].Play();
	}


	private void NextTrack()
	{
		currTrack = (currTrack + 1) % tracks.Length;
		tracks[currTrack].Play();
	}

	public void ClickSfx()
	{
		click.Play();
	}

	public void SuccessSfx()
	{
		success.Play();
	}

	public void FailSfx()
	{
		fail.Play();
	}




}
