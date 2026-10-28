using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PathManager : Node
{
	public static PathManager Instance { get; private set; }

	[Signal] public delegate void UpdatedPathTrackingStateEventHandler();
	[Signal] public delegate void SolutionAttemptEventHandler(string result);


	public string Path { get; private set; } = "";

	public bool Tracking { get; private set; } = false;

	public List<int> SolvedIdList { get; private set; } = [];
	private int solvedCount = 0;
	

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
		if (Tracking && worldId <= 9)
			Path += $"{worldId}";
	}

	public void UpdatePathTrackingState()
	{
		if(Tracking) 
			CheckSolution();
		else
		{
			Path = "";
			AudioManager.Instance.PlaySfx("click");
		}
			
		Tracking = !Tracking;
		EmitSignal(SignalName.UpdatedPathTrackingState);
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
		if (solutionsCf.GetSections().Contains(Path))
			id = (int)solutionsCf.GetValue(Path,"id");

		

		if (id == -1 || SolvedIdList.Contains(id) || (id == 10 && !SolvedAllPuzzles()))
		{
			AudioManager.Instance.PlaySfx("fail");
			EmitSignal(SignalName.SolutionAttempt, "fail");
		}
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
			EmitSignal(SignalName.SolutionAttempt, "success");
		}
		
		Path = "";
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
