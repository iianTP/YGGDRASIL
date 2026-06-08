using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PathManager : Node
{
	public static PathManager Instance { get; private set; }

	public List<string> SolvedList { get; private set; } = [];
	public List<int> SolvedIdList { get; private set; } = [];
	private int solvedCount = 0;
	private bool started = false;
	private string path = "";


	public override void _Ready()
	{
		Instance = this;
		LoadPuzzlesSolved();
	}

	private void LoadPuzzlesSolved()
	{
		ConfigFile cf = Utils.Instance.cf;

		cf.Load("user://solved.cfg");

		string[] idList = cf.GetSections();
		foreach (string id in idList)
		{
			SolvedIdList.Add(id.ToInt());
			solvedCount++;
		}
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
		{
			path = "";
			AudioManager.Instance.ClickSfx();
		}
			
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

		int id = -1;
		if (cf.GetSections().Contains(path))
			id = (int)cf.GetValue(path,"id");

		if (id == -1 || SolvedIdList.Contains(id))
			AudioManager.Instance.FailSfx();
		else
		{

			SolvedIdList.Add(id);
			
			cf.Clear();
			cf.Load("user://solved.cfg");
			cf.SetValue($"{id}","success",true);
			cf.Save("user://solved.cfg");

			solvedCount++;
			AudioManager.Instance.SuccessSfx();	
		}
	}

	public void ClearSolvedPuzzles()
	{
		SolvedIdList = [];
		solvedCount = 0;
	}


}
