using Godot;
using System;

public partial class DialogBox : TextureRect
{
	[Export] private TextureRect displayImage;
	[Export] private RichTextLabel displayText;

	public void SetDisplay((string txt, CompressedTexture2D img) display)
	{
		
		if (display.img != null)
		{
			displayImage.Texture = display.img;
			displayImage.Size = new Vector2(50,50);
		}
		else
		{
			displayText.Theme.DefaultFontSize = 8;
			if (display.txt.StartsWith("\nREFLECT"))
			 	displayText.Theme.DefaultFontSize = 7;
			if (display.txt.StartsWith("\nREFLETIR"))
			 	displayText.Theme.DefaultFontSize = 6;
			displayText.Text = display.txt;
		} 
	}

	public void SetFontSize(int size)
	{
		displayText.Theme.DefaultFontSize = size;
	}


}
