using Godot;
using iwbe.business.model;
using iwbe.common.observables;
using iwbe.presentation.common;
using System;

public partial class ProjectList : Control
{
    private PackedScene ListItemTemplate;

    public VBoxContainer ListNode { get; private set; }

    private ObservableDataCollection<ProjectId> _projectIds;
    public ObservableDataCollection<ProjectId> ProjectIds
    {
        get
        {
            return _projectIds;
        }
        set
        {
            if (_projectIds != null)
            {
                _projectIds.OnListChanged -= _projectIds_OnListChanged;
            }

            _projectIds = value;
            _projectIds.OnListChanged += _projectIds_OnListChanged;

            var children = ListNode.GetChildren();
            foreach (var child in children)
            {
                RemoveChild(child);
                child.QueueFree();
            }

            foreach (var newChild in value)
            {
                // Add Godot child node
                var newChildNode = ListItemTemplate.Instantiate<ProjectListItem>();

            }
        }
    }

    public override void _Ready()
	{
        ListItemTemplate = SceneLoader.Load("presentation/views/workspace/project/ProjectListItem.tscn");

        ListNode = GetNode("VBoxContainer/ScrollContainer/List") as VBoxContainer;
    }
    
    private void _projectIds_OnListChanged(IObservableData sender, OnChangedEventArgs<ProjectId> e)
    {
        throw new NotImplementedException();
    }

}
