using Godot;
using iwbe.business.model;
using iwbe.common.observables;
using System;

public partial class ProjectList : Control
{
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
            _projectIds = value;
        }
    }

    public override void _Ready()
	{
        ListNode = GetNode("VBoxContainer/List") as VBoxContainer;
    }
}
