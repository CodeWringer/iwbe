using Godot;
using System;

public partial class WorkspaceBar : Control
{
    private Main _mainNode;

    private VBoxContainer _buttonList;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		_mainNode = GetTree().Root.GetNode<Main>("Main");
        _buttonList = GetNode<VBoxContainer>("VBoxContainer");
    }
}
