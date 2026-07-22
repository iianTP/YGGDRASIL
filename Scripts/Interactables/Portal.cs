using Godot;
using System;

public partial class Portal : Interactable
{
	private TravelManager tm;
	
	[Export] private Utils.Directions direction = 0;
	[Export] private Sprite2D sprite;

	public bool active = true;

	public override void _Ready()
	{
		tm = TravelManager.Instance;
		sprite.Rotation = (int)direction * (float)Math.PI/180;
	}

	public override void _on_area_exited(Area2D area)
	{
		active = true;
	}

	protected override void Action()
	{
		if (active)
			Vignette.Instance.Transition(1,0.25f,1,1,()=>{tm.Travel(direction);});
	}

	public Utils.Directions GetDirection()
	{
		return direction;
	}

}
