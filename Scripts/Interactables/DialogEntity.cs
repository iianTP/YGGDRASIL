using Godot;
using System;


public partial class DialogEntity : Interactable
{
	[Export] private PackedScene dialogBox;
	private DialogBox dialogBoxInstance;

	[Export] private CompressedTexture2D image;
	[Export] protected string[] dialogue;
	private int dialogueIndex = 0;

	public override void _on_area_exited(Area2D area)
	{
		if (area.IsInGroup("Player"))
			dialogBoxInstance.CallDeferred("free");		
	}

	protected override void Action()
	{
		dialogBoxInstance = (DialogBox)dialogBox.Instantiate();
		dialogBoxInstance.Position = new Vector2(-48,-90);
		dialogBoxInstance.SetDisplay(GetDisplay());
		AddChild(dialogBoxInstance);
	}

	private (string txt, CompressedTexture2D img) GetDisplay()
	{
		if (image == null && dialogue == null) return (null, null);

		if (image != null)
		{
			return (null, image);
		} else
		{
			return (GetDialogue(), null);
		}
	}

	private string GetDialogue()
	{
		string d = Tr(dialogue[dialogueIndex]).Replace("\\n","\n");
		dialogueIndex = (dialogueIndex + 1) % dialogue.Length;
		return d;
	}
}
