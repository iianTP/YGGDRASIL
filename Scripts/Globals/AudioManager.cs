using Godot;
using System;

public partial class AudioManager : Node
{
	public static AudioManager Instance { get; private set; }

	[Export] private AudioStreamPlayer2D[] tracks;
	[Export] private AudioStreamPlayer2D secretTrack;

	[Export] private AudioStreamPlayer2D click;
	[Export] private AudioStreamPlayer2D success;
	[Export] private AudioStreamPlayer2D fail;


	private int currTrack = 0;

	private bool musicOn = true;
	private bool sfxOn = true;

	public override void _Ready()
	{
		Instance = this;
		foreach (AudioStreamPlayer2D track in tracks)
			track.Finished += NextTrack;
	}

	public void StartMusic()
	{
		if (!musicOn) return;
		
		tracks[0].Play();
	}

	public void StopMusic()
	{
		tracks[currTrack].Stop();
		currTrack = 0;
	}

	private void NextTrack()
	{
		currTrack = (currTrack + 1) % tracks.Length;
		tracks[currTrack].Play();
	}

	public void PlaySecretTrack()
	{
		secretTrack.Play();
	}

	public void StopSecretTrack()
	{
		secretTrack.Stop();
	}

	public void PlaySfx(string sfx)
	{
		if (!sfxOn) return;
		
		switch (sfx){
			case "click":
				click.Play();
				break;
			case "success":
				success.Play();
				break;
			case "fail":
				fail.Play();
				break;
			default:
				break;
		}	
	}

	public void SetAudio(bool music, bool sfx)
	{
		musicOn = music;
		sfxOn = sfx;
	}


}
