using Godot;
using System;

public partial class MainMenuBar : Control
{
	private MenuButton _menuProject;
	private Main _main;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		_menuProject = GetNode<MenuButton>("MenuBar/MenuButtonProject");
        _main = GetTree().Root.GetNode<Main>("Main");

        _menuProject.GetPopup().IdPressed += MainMenuBar_IdPressed;
    }

    private void MainMenuBar_IdPressed(long id)
    {
        throw new NotImplementedException();
    }
}
