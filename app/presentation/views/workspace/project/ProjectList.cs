using Godot;
using iwbe.business.model;
using iwbe.common.observables;
using iwbe.presentation.common;
using System;

public partial class ProjectList : Control
{
    private PackedScene ListItemTemplate;

    private Label _titleNode;

    public VBoxContainer ListNode { get; private set; }

    private string _title;
    [Export]
    public string Title {
        get { return _title; } 
        set {
            _title = value;
            if (_titleNode != null)
            {
                _titleNode.Text = _title;
            }
        }
    }

    private ObservableDataCollection<ProjectId> _projectIds;
    public ObservableDataCollection<ProjectId> ProjectIds
    {
        get { return _projectIds; }
        set
        {
            if (_projectIds != null) {
                _projectIds.ListChanged -= ProjectIds_OnListChanged;
            }
            _projectIds = value;
            if (_projectIds != null)
            {
                _projectIds.ListChanged += ProjectIds_OnListChanged;
            }
        }
    }

    public override void _Ready()
	{
        ProjectIds.ListChanged += ProjectIds_OnListChanged;

        ListItemTemplate = SceneLoader.Load(ProjectListItem.Template);
        ListNode = GetNode("VBoxContainer/ScrollContainer/List") as VBoxContainer;

        _titleNode = GetNode<Label>("VBoxContainer/PanelContainer/MarginContainer/Label");
        _titleNode.Text = _title;
    }

    /// <summary>
    /// Returns the child list item identified by the given id, or null, if there is no item 
    /// with that id. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private ProjectListItem GetChildById(ProjectId id)
    {
        var childNodes = ListNode.GetChildren();
        foreach (var child in childNodes)
        {
            var castNode = child as ProjectListItem;
            if (castNode != null)
            {
                if (castNode.ProjectId.ID == id.ID)
                {
                    return castNode;
                }
            }
        }
        return null;
    }

    public void Synchronize()
    {

    }

    private void ProjectIds_OnListChanged(IObservableData sender, ChangedEventArgs<ProjectId> e)
    {
        if (e.ChangeType == CollectionChangeTypes.ADD)
        {
            foreach (var element in e.Elements) {
                ProjectListItem newChildNode = ListItemTemplate.Instantiate<ProjectListItem>();
                newChildNode.ProjectId = element.Element.Value;
                newChildNode.PinClicked += ListItemNode_PinClicked;
                newChildNode.DeleteClicked += ListItemNode_DeleteClicked;
                newChildNode.Clicked += ListItemNode_Clicked;
                ListNode.AddChild(newChildNode);
            }
        }
        else if (e.ChangeType == CollectionChangeTypes.REMOVE)
        {
            foreach (var element in e.Elements)
            {
                var child = GetChildById(element.Element.Value);
                if (child != null)
                {
                    if (child.ProjectId.ID == element.Element.Value.ID)
                    {
                        ListNode.RemoveChild(child);
                        child.PinClicked -= ListItemNode_PinClicked;
                        child.DeleteClicked -= ListItemNode_DeleteClicked;
                        child.Clicked -= ListItemNode_Clicked;
                        child.QueueFree();
                        break;
                    }
                }
            }
        }
        else if (e.ChangeType == CollectionChangeTypes.MOVE)
        {
            foreach (var element in e.Elements)
            {
                var child = GetChildById(element.Element.Value);
                if (child != null)
                {
                    ListNode.MoveChild(child, element.NewIndex);
                }
            }
        }
        else if (e.ChangeType == CollectionChangeTypes.REPLACE || e.ChangeType == CollectionChangeTypes.ELEMENT)
        {
            foreach (var element in e.Elements)
            {
                var child = GetChildById(element.Element.Value);
                if (child != null)
                {
                    child.ProjectId = element.Element.Value;
                }
            }
        }
    }

    private void ListItemNode_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ListItemNode_DeleteClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ListItemNode_PinClicked(object sender, EventArgs e)
    {
        var listItem = sender as ProjectListItem;
        listItem.ProjectId.IsPinned.Value = true;
        // TODO: Update lists
    }
}
