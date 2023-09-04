using iwbe.business.state;
using Godot;
using System;
using iwbe.presentation.workspace;
using iwbe.presentation.workspace.workspaces;
using System.Linq;
using iwbe.business.command;

/// <summary>
/// The entry point to the application. Script of the main node. 
/// </summary>
public partial class Main : Control
{
	/// <summary>
	/// The node beneath which the currently active workspace is placed. 
	/// </summary>
	private Control _mainViewPort;

	/// <summary>
	/// Loads workspace resources. 
	/// </summary>
	private WorkspaceLoader _workspaceLoader;

    /// <summary>
    /// A reference to the state object, as fetched from the auto-loaded ApplicationStateNode. 
    /// </summary>
    public ApplicationState State { get; private set; }

	/// <summary>
	/// Application-level command bus. 
	/// </summary>
	public ApplicationCommandBus CommandBus { get; private set; }

	public override void _Ready()
	{
		State = ApplicationState.GetFromSceneTree(this);
		_mainViewPort = GetNode("VBoxContainer/HBoxContainer/MainViewport") as Control;

		CommandBus = new ApplicationCommandBus();

        _workspaceLoader = new WorkspaceLoader();
		_workspaceLoader.Register(new ArticleWorkspace());
		_workspaceLoader.Load();
    }

    /// <summary>
    /// Replaces the current view with the given view. 
    /// </summary>
    /// <param name="workspaceName">Name of the workspace to activate. </param>
    /// <exception cref="Exception">Thrown, if no workspace with the given name exists. </exception>
    public void SetView(string workspaceName)
	{
		var workspaceKv = _workspaceLoader.Workspaces.Where(it => it.Key.Name.Equals(workspaceName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

		if (workspaceKv.Key == null)
		{
			throw new Exception("Bad view name: " + workspaceName);
		}

		// First, remove any current children. 
		var toRemove = _mainViewPort.GetChildren();
		for (int i = toRemove.Count - 1; i >= 0; i--)
		{
			_mainViewPort.RemoveChild(toRemove[i]);
		}

		// Next, set up a new child for the corresponding workspace. 
		var instance = workspaceKv.Value.Instantiate();
		_mainViewPort.AddChild(instance);
	}
}
