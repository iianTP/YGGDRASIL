using Godot;
using System;

public partial class TravelManager : Node
{
	public static TravelManager Instance;
	private Vector2 playerPos = new Vector2(1,1);


	private string[][] worlds = [
		["white","yellow","red"],
		["purple","gray","orange"],
		["blue","green","black"]
	];

	public override void _Ready()
	{
		Instance = this;
	}

	public void Travel(Utils.Directions d)
	{
		

		playerPos += Utils.Instance.AngleToDirection((int)d);

		PackedScene w = GD.Load<PackedScene>($"res://Scenes/Worlds/{worlds[(int)playerPos.Y][(int)playerPos.X]}.tscn");
		World world = (World)w.Instantiate();

		Utils.Directions arrivalPortal = Utils.Instance.GetOpositeDirection(d);
		world.PositionPlayer(arrivalPortal);
		
		GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToNode, world);
	}


}
