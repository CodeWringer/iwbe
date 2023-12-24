using Godot;
using System;

public partial class ImageButton : AspectRatioContainer
{
    public EventHandler Pressed;
    public EventHandler Toggled;

    private TextureRect _textureRect;
    private Button _button;

    private Texture2D _imageTexture;
    [Export(PropertyHint.File)]
    public Texture2D ImageTexture
    {
        get { return _imageTexture; }
        set { _imageTexture = value; }
    }

    [Export]
    public bool Disabled
    {
        get { return _button.Disabled; }
        set { _button.Disabled = value; }
    }

    [Export]
    public bool Toggle
    {
        get { return _button.ToggleMode; }
        set { _button.ToggleMode = value; }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        _textureRect = GetNode<TextureRect>("Button/MarginContainer/TextureRect");
        _textureRect.Texture = _imageTexture;

        _button = GetNode<Button>("Button");
        _button.Pressed += _button_Pressed;
        _button.Toggled += _button_Toggled;
    }

    private void _button_Toggled(bool toggledOn)
    {
        Toggled?.Invoke(this, EventArgs.Empty);
    }

    private void _button_Pressed()
    {
        Pressed?.Invoke(this, EventArgs.Empty);
    }
}
