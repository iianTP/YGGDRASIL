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

	private bool musicOn = true;
	private bool sfxOn = true;

	public override void _Ready()
	{
		Instance = this;
	}

	public void StartMusic()
	{
		if (!musicOn) return;

		foreach (AudioStreamPlayer2D track in tracks)
			track.Finished += NextTrack;
		
		tracks[0].Play();
	}


	private void NextTrack()
	{
		currTrack = (currTrack + 1) % tracks.Length;
		tracks[currTrack].Play();
	}

	public void ClickSfx()
	{
		if (!sfxOn) return;
		click.Play();
	}

	public void SuccessSfx()
	{
		if (!sfxOn) return;
		success.Play();
	}

	public void FailSfx()
	{
		if (!sfxOn) return;
		fail.Play();
	}

	public void SetAudio(bool music, bool sfx)
	{
		musicOn = music;
		sfxOn = sfx;
	}


}
