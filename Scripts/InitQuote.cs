using Godot;
using System;

public partial class InitQuote : CanvasLayer
{
	[Export] private Vignette vignette;
	[Export] private Timer timer;
	[Export] private RichTextLabel quote;

	public override void _Ready()
	{
		quote.Text = Tr("OLDGUY_1");
		timer.Timeout += () => { 
			vignette.Transition(1,1,3,4,() => {
				AudioManager.Instance.StartMusic();
				GetTree().ChangeSceneToFile("res://Scenes/Worlds/gray.tscn");
			}); 
		};
		timer.Start();
	}

}
