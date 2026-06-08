using Godot;
using System;

public partial class Config : Control
{
	private bool musicOn = true;
	private bool sfxOn = true;


	public void _on_save_pressed()
	{
		AudioManager.Instance.SetAudio(musicOn, sfxOn);
		GetTree().ChangeSceneToFile("res://Scenes/UI/menu.tscn");
	}

	public void _on_reset_pressed()
	{
		ConfigFile cf = Utils.Instance.cf;
		cf.Clear();
		cf.Save("user://solved.cfg");
		PathManager.Instance.ClearSolvedPuzzles();
	}

	public void _on_music_box_toggled(bool toggled)
	{
		musicOn = toggled;
	}

	public void _on_sfx_box_toggled(bool toggled)
	{
		sfxOn = toggled;
	}
}
