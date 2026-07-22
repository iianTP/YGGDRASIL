using Godot;
using System;

public partial class Menu : CanvasLayer
{

	[Export] private Button play;
	[Export] private Button config;
	[Export] private Button quit;
	[Export] private Controls controls;

	[Export] private Vignette vignette;
	[Export] private HBoxContainer hbc;
	[Export] private TextureRect vhs;

	public override void _Ready()
	{
		play.Text = Tr("BT_PLAY");
		config.Text = Tr("BT_CONFIG");
		quit.Text = Tr("BT_QUIT");
		controls.Text = Tr("CONTROLS");

		Utils.Instance.UpdateRichPresence("clear_location");
		Utils.Instance.UpdateRichPresence("update_details", "In Menu");
		
		vignette.SetBlack(0);

		if (vhs.Material is ShaderMaterial s)
			s.SetShaderParameter("aberration",0.01);

	}

	public void _on_play_pressed()
	{
		AudioManager.Instance.StopSecretTrack();
		hbc.Hide();
		vignette.Transition(1,1,3,4,StartGame);
	}

	public void _on_config_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/UI/config.tscn");
	}

	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	private void StartGame()
	{
		AudioManager.Instance.StartMusic();
		TravelManager.Instance.ResetPos();
		Utils.Instance.UpdateRichPresence("update_details", "Wandering...");
		GetTree().ChangeSceneToFile("res://Scenes/Worlds/gray.tscn");
	}
}
