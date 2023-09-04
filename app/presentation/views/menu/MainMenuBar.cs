using Godot;
using System;

public partial class MainMenuBar : Control
{
	private Main _mainNode;

	private MenuButton _menuButtonProject;
	private PopupMenu _popupMenuProject;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		_mainNode = GetTree().Root.GetNode<Main>("Main");

        _menuButtonProject = GetNode<MenuButton>("MenuBar/ProjectMenuButton");
		_popupMenuProject = _menuButtonProject.GetPopup();
		_popupMenuProject.Connect("index_pressed", new Callable(this, "_OnIndexPressedProject"));
    }

	private void OnIndexPressedProject(int index)
	{
		if (index == 0) { // New
			//_mainNode.CommandBus.Execute(new NewProjectCommand());
		}
		else if (index == 1) // Open
		{

		}
        else if (index == 2) // Save
        {

        }
        else if (index == 3) // Close
        {

        }
    }
}
