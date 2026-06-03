using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PathManager : Node
{
	public static PathManager Instance { get; private set; }

	public List<string> SolvedList { get; private set; } = [];
	private int solvedCount = 0;
	private bool started = false;
	private string path = "";


	public override void _Ready()
	{
		Instance = this;
	}

	public void AppendPath(int worldId)
	{
		if (started && !path.Contains($"{worldId}"))
			path += $"{worldId}";
	}

	public void UpdatePathTrackingState()
	{
		if(started) 
			CheckSolution();
		else
			path = "";
			
		started = !started;
	}

	public bool SolvedAllPuzzles()
	{
		return solvedCount >= 9;
	}

	private void CheckSolution()
	{
		ConfigFile cf = Utils.Instance.cf;

		cf.Load("res://Assets/Patterns/solutions.cfg");
		
		if (cf.GetSections().Contains(path))
		{
			string color = (string)cf.GetValue(path,"color");
			SolvedList.Add(color);
			solvedCount++;
			AudioManager.Instance.SuccessSfx();
		}
	}


}
