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
			displayText.Text = display.txt;
		} 
	}


}
