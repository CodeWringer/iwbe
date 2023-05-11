using iwbe.business.state;
using Godot;
using System;

/// <summary>
/// The entry point to the application. 
/// </summary>
public partial class Main : Control
{
	/// <summary>
	/// The node beneath which the currently active workspace is placed. 
	/// </summary>
	private Control _workspaceViewPort;

	private PackedScene _workspaceResourceArticles;

	/// <summary>
	/// A reference to the state object, as fetched from the auto-loaded ApplicationStateNode. 
	/// </summary>
	internal ApplicationState State { get; private set; }

	public override void _Ready()
	{
		State = ApplicationState.GetFromSceneTree(this);
		_workspaceViewPort = GetNode("VBoxContainer/HBoxContainer/WorkspaceViewport") as Control;
		_workspaceResourceArticles = ResourceLoader.Load<PackedScene>("res://presentation/views/workspace/article/ArticleWorkspace.tscn");
	}

	/// <summary>
	/// Activates a workspace of the given type. 
	/// </summary>
	/// <param name="workspaceName"></param>
	public void SetWorkspace(string workspaceName)
	{
		var workspace = GetWorkspaceByName(workspaceName);

		if (workspace == null)
		{
			throw new Exception("Bad workspace name: " + workspaceName);
		}

		// First, remove any current children. 
		var toRemove = _workspaceViewPort.GetChildren();
		for (int i = toRemove.Count - 1; i >= 0; i--)
		{
			_workspaceViewPort.RemoveChild(toRemove[i]);
		}

		// Next, set up a new child for the corresponding workspace. 
		var instance = workspace.Instantiate();
		_workspaceViewPort.AddChild(instance);
	}

	/// <summary>
	/// Returns a PackedScene that corresponds to the given workspace name, or null, 
	/// if no workspace of the given name exists. 
	/// </summary>
	/// <param name="workspaceName">Name of a workspace. E.g. "articles"</param>
	/// <returns></returns>
	private PackedScene GetWorkspaceByName(string workspaceName)
	{
		var _lowerCaseName = workspaceName.ToLowerInvariant();

		if (_lowerCaseName == "articles")
		{
			return _workspaceResourceArticles;
		}
		else
		{
			return null;
		}
	}
}
