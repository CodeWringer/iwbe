using Godot;
using iwbe.business.model;
using iwbe.business.state;
using iwbe.common.observables;
using iwbe.presentation.common;
using System;
using System.Collections.Generic;

public partial class ProjectList : Control
{
    private PackedScene ListItemTemplate;

    public VBoxContainer ListNode { get; private set; }

    public ObservableDataCollection<ProjectId> ProjectIds = new ObservableDataCollection<ProjectId>();

    public override void _Ready()
	{
        ListItemTemplate = SceneLoader.Load("presentation/views/workspace/project/ProjectListItem.tscn");
        ListNode = GetNode("VBoxContainer/ScrollContainer/List") as VBoxContainer;

        ProjectIds.ListChanged += ProjectIds_OnListChanged;

        var applicationState = ApplicationState.GetFromSceneTree(this);
        ProjectIds.AddRange(applicationState.ProjectIds);
    }

    private void ProjectIds_OnListChanged(IObservableData sender, ChangedEventArgs<ProjectId> e)
    {
        if (e.ChangeType == CollectionChangeTypes.ADD)
        {
            foreach (var element in e.Elements) {
                // Add Godot child node
                var newChildNode = ListItemTemplate.Instantiate<ProjectListItem>();
                newChildNode.ProjectId = element.Element.Value;
                ListNode.AddChild(newChildNode);
            }
        }

        //if (_projectIds != null)
        //{
        //    _projectIds.OnListChanged -= _projectIds_OnListChanged;
        //}

        //_projectIds = value;
        //_projectIds.OnListChanged += _projectIds_OnListChanged;

        //var children = ListNode.GetChildren();
        //foreach (var child in children)
        //{
        //    RemoveChild(child);
        //    child.QueueFree();
        //}

        //foreach (var newChild in value)
        //{
        //    // Add Godot child node
        //    var newChildNode = ListItemTemplate.Instantiate<ProjectListItem>();
        //    newChildNode.ProjectId = new ProjectId("New project", null, Guid.NewGuid(), DateTime.Now, DateTime.Now);
        //    AddChild(newChildNode);
        //}
    }
}
