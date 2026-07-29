using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PathManager : Node
{
	public static PathManager Instance { get; private set; }

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
		ConfigFile cf = new ConfigFile();

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
			AudioManager.Instance.PlaySfx("click");
		}
			
		started = !started;
	}

	public bool SolvedAllPuzzles()
	{
		return solvedCount >= 9;
	}

	public bool SolvedSecretPuzzle()
	{
		return SolvedIdList.Contains(10);
	}

	private void CheckSolution()
	{
		ConfigFile solutionsCf = new ConfigFile();

		solutionsCf.Load("res://Assets/Patterns/solutions.cfg");

		int id = -1;
		if (solutionsCf.GetSections().Contains(path))
			id = (int)solutionsCf.GetValue(path,"id");

		

		if (id == -1 || SolvedIdList.Contains(id) || (id == 10 && !SolvedAllPuzzles()))
			AudioManager.Instance.PlaySfx("fail");
		else
		{
			
			
			SolvedIdList.Add(id);

			ConfigFile solvedCf = new ConfigFile();
			
			solvedCf.Clear();
			solvedCf.Load("user://solved.cfg");
			solvedCf.SetValue($"{id}","success",true);
			solvedCf.Save("user://solved.cfg");

			solvedCount++;

			Utils.Instance.UpdateRichPresence("update_state",solvedCount);

			AudioManager.Instance.PlaySfx("success");	
		}
	}

	public void ClearSolvedPuzzles()
	{
		SolvedIdList = [];
		solvedCount = 0;
		Utils.Instance.UpdateRichPresence("update_state",solvedCount);
	}

	public int PuzzlesSolved()
	{
		return solvedCount;
	}

	

}
