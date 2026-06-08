using Godot;
using System;

public partial class Utils : Node
{
	public static Utils Instance { get; private set; }

	public readonly ConfigFile cf = new ConfigFile();
	public readonly Random rng = new Random();

	public enum Directions
	{
		NE = 135, N = 180, NW = -135,
		E = 90,            W = -90,
		SE = 45,  S = 0,   SW = -45
	}

	public enum Letters{ Y,G1,G2,D,R,A,S,I,L }

	public override void _Ready()
	{
		Instance = this;
	}

	public Vector2 AngleToDirection(int d)
	{
		float direction = (d - 90) * (float)Math.PI/180;
		int x = -(int)Math.Round(Math.Cos(direction));
		int y = -(int)Math.Round(Math.Sin(direction));
		return new Vector2(x,y);
	}

	public Directions GetOpositeDirection(Directions d)
	{
		if (d > 0) return d - 180;
		else return d + 180;
	}

	public string[] GetFileLines(string filePath)
	{
		// Open the file for reading
		using var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
		
		if (file == null)
		{
			GD.PrintErr($"Failed to open file: {filePath}");
			return Array.Empty<string>();
		}

		// Read the whole file content into a single string
		string fileText = file.GetAsText();

		// Split text by newline. Using true removes trailing carriage returns (\r)
		string[] lines = fileText.Split("\n", System.StringSplitOptions.None);
		
		return lines;
	}

}
