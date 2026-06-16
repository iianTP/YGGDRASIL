using Godot;
using System;

public partial class Config : CanvasLayer
{
	[Export] private CheckBox musicBox;
	[Export] private Button lang;
	[Export] private Button reset;
	[Export] private Button save;

	private bool musicOn = true;
	private bool sfxOn = true;


	public override void _Ready()
	{
		UpdateText();
	}

	private void UpdateText()
	{
		musicBox.Text = Tr("BT_MUSIC");
		lang.Text = Tr("BT_LANG");
		reset.Text = Tr("BT_RESET");
		save.Text = Tr("BT_SAVE");
	}

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

	public void _on_lang_pressed()
	{
		string locale = "en";
		if (TranslationServer.GetLocale() == "en")
			locale = "pt";

		TranslationServer.SetLocale(locale);
		UpdateText();
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
