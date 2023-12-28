using Godot;
using iwbe.business.model;
using System;

public partial class ProjectListItem : PanelContainer
{
	public static readonly string Template = "presentation/views/workspace/project/ProjectListItem.tscn";

    public event EventHandler PinClicked;
	public event EventHandler Clicked;
	public event EventHandler DeleteClicked;

	private ImageButton _pinButton;
	private Button _button;
	private ImageButton _deleteButton;
	private Label _nameLabel;
	private Label _pathLabel;

	private ProjectId _projectId;

    public ProjectId ProjectId
	{
		get { return  _projectId; }
		set {
			_projectId = value;

			if (_nameLabel == null || _pathLabel == null) return;

			if (value == null)
			{
				_nameLabel.Text = "";
				_pathLabel.Text = "";
			} else
			{
                _nameLabel.Text = value.Name.Value;
                _pathLabel.Text = value.PathOnDisk.Value;
            }
		}
	}

    public override void _Ready()
	{
		_pinButton = GetNode<ImageButton>("HBoxContainer/ButtonPin");
		_pinButton.Pressed += OnPinButton_Pressed;

        _button = GetNode<Button>("HBoxContainer/Button");
		_button.Pressed += OnClicked;

        _deleteButton = GetNode<ImageButton>("HBoxContainer/ButtonDelete");
        _deleteButton.Pressed += OnDeleteButton_Pressed;

        _nameLabel = GetNode<Label>("HBoxContainer/Button/HBoxContainer/CenterContainer/LabelName");
		if (_projectId != null)
		{
			_nameLabel.Text = _projectId.Name.Value;
		}

        _pathLabel = GetNode<Label>("HBoxContainer/Button/HBoxContainer/CenterContainer2/LabelPath");
		if (_projectId != null)
		{
            _pathLabel.Text = _projectId.PathOnDisk.Value;
		}
    }

    private void OnPinButton_Pressed(object sender, EventArgs e)
    {
        PinClicked?.Invoke(this, e);
    }

    private void OnDeleteButton_Pressed(object sender, EventArgs e)
    {
        DeleteClicked?.Invoke(this, e);
    }

    private void OnClicked()
	{
		Clicked?.Invoke(this, EventArgs.Empty);
    }
}
