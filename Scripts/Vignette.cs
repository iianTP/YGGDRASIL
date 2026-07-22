using Godot;
using System;

public partial class Vignette : Control
{
	public static Vignette Instance { get; private set; }

	[Export] private ColorRect vignette;
	[Export] private TextureRect vhs;

	public override void _Ready()
	{
		Instance = this;
		
		if (Owner.Name == "Pink")
			SetWhite(1);
		else
			SetBlack(1);

		if (Owner.Name != "Menu")
			Transition(0,0.01f,1,2,()=>{});
		
	}

	public void Transition(float finalTr, float finalAb, float transitionTime, float aberrationTime, Action action)
	{

		Tween aberration = CreateTween().SetTrans(Tween.TransitionType.Sine);
		Tween transition = CreateTween().SetTrans(Tween.TransitionType.Sine);
	
		transition.TweenProperty(vignette,"color:a",finalTr,transitionTime);

		if (vhs.Material is ShaderMaterial s)
			aberration.TweenProperty(s,"shader_parameter/aberration",finalAb,aberrationTime).Connect("finished",Callable.From(action));

	}

	public void SetWhite(float a)
	{
		vignette.Color = new Color(1,1,1,a);
	}

	public void SetBlack(float a)
	{
		vignette.Color = new Color(0,0,0,a);
	}
	
}
