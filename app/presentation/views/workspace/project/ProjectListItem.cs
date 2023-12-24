using Godot;
using iwbe.business.model;
using System;

public partial class ProjectListItem : PanelContainer
{
	event EventHandler PinClicked;
	event EventHandler Clicked;
	event EventHandler DeleteClicked;

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
		_pinButton = GetNode<ImageButton>("Button/HBoxContainer/ButtonPin");
		_pinButton.Pressed += OnPinButton_Pressed;

        _button = GetNode<Button>("Button");
		_button.Pressed += OnClicked;

        _deleteButton = GetNode<ImageButton>("Button/HBoxContainer/ButtonDelete");
        _deleteButton.Pressed += OnDeleteButton_Pressed;

        _nameLabel = GetNode<Label>("Button/HBoxContainer/CenterContainer/LabelName");
        _pathLabel = GetNode<Label>("Button/HBoxContainer/CenterContainer2/LabelPath");
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
