using Godot;
using iwbe.business.state;
using iwbe.presentation.common;
using System;
using System.Linq;

public partial class Startup : Control
{
    public static readonly string Template = "presentation/views/startup/Startup.tscn";

    private ProjectList _pinnedProjectListNode;

    private ProjectList _recentProjectListNode;

    public override void _Ready()
	{
        var applicationState = ApplicationState.GetFromSceneTree(this);

        var pinnedProjects = applicationState.ProjectIds.Where(it => it.Value.IsPinned.Value == true);
        var recentProjects = applicationState.ProjectIds.Where(it => it.Value.IsPinned.Value == false);

        _pinnedProjectListNode = GetNode<ProjectList>("VBoxContainer/PinnedProjectList");
        _recentProjectListNode = GetNode<ProjectList>("VBoxContainer/RecentProjectList");

        _pinnedProjectListNode.ProjectIds.AddRange(pinnedProjects);
        _recentProjectListNode.ProjectIds.AddRange(recentProjects);
    }
}
