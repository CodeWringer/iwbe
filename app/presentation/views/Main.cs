using iwbe.business.state;
using Godot;
using System;
using iwbe.presentation.workspace;
using iwbe.presentation.workspace.workspaces;
using System.Linq;
using iwbe.business.command;
using iwbe.presentation.navigation;
using iwbe.presentation.common;

/// <summary>
/// The entry point to the application. Script of the main node. 
/// </summary>
public partial class Main : Control
{
	/// <summary>
	/// Loads workspace resources. 
	/// </summary>
	private WorkspaceLoader _workspaceLoader;

	private PackedScene _startupScene = SceneLoader.Load("presentation/views/startup/Startup.tscn");

    /// <summary>
    /// A reference to the state object, as fetched from the auto-loaded ApplicationStateNode. 
    /// </summary>
    public ApplicationState State { get; private set; }

	/// <summary>
	/// Application-level command bus. 
	/// </summary>
	public ApplicationCommandBus CommandBus { get; private set; }

	/// <summary>
	/// The node beneath which the currently active workspace is placed. 
	/// </summary>
	public Control MainViewPort { get; private set; }

	/// <summary>
	/// Allows and handles view navigation. Used to activate workspaces and dialogs and navigate within them. 
	/// </summary>
	public ViewNavigator Navigator { get; private set; }

	public override void _Ready()
	{
		State = ApplicationState.GetFromSceneTree(this);
		MainViewPort = GetNode("VBoxContainer/HBoxContainer/MainViewport") as Control;

		CommandBus = new ApplicationCommandBus();
		Navigator = new ViewNavigator(this, MainViewPort);

        _workspaceLoader = new WorkspaceLoader();
		_workspaceLoader.Register(new ArticleWorkspace());
		_workspaceLoader.Load();

		var startupScene = _startupScene.Instantiate();
		MainViewPort.AddChild(startupScene);
    }
}
