using Godot;
using iwbe.presentation.common;
using System;

/// <summary>
/// A dialog window with custom content. 
/// 
/// <br></br>
/// 
/// The dialog is initially invisible and must be displayed via the Show method or Visible property. 
/// </summary>
public partial class CustomDialogWindow : VBoxContainer
{
    private static readonly PackedScene _modalDialogScene = SceneLoader.Load("presentation/views/dialog/ModalDialogContainer.tscn");

    private Label _labelTitle;
    private Button _cancelButton;
    private Node _modalScene;

    /// <summary>
    /// Text displayed at the head of the dialog. 
    /// </summary>
    [Export]
	public string Title = "Title";

    /// <summary>
    /// If true, will not allow the user to interact with anything but the dialog. 
    /// </summary>
    [Export]
    public bool Modal = false;

    /// <summary>
    /// If Modal is true, then this value controls whether a user can dismiss the dialog by simply clicking anywhere outside the window. 
    /// </summary>
    [Export]
    public bool LazyDismiss = true;

	public override void _Ready()
	{
        Hide();

        _labelTitle = GetNode<Label>("DialogMenuBar/MarginContainer/HBoxContainer/Title");
        _labelTitle.Text = Title;

        _cancelButton = GetNode<Button>("DialogMenuBar/MarginContainer/HBoxContainer/CancelButton");
        _cancelButton.Pressed += OnCancelButtonPressed;

        VisibilityChanged += OnVisibilityChanged;
    }

    private void OnVisibilityChanged()
    {
        if (!Modal)
        {
            return;
        }

        var parent = GetParent();
        if (Visible)
        {
            _modalScene = _modalDialogScene.Instantiate();
            parent.AddChild(_modalScene);
            parent.RemoveChild(this);

            var newParent = _modalScene.GetChild(0);
            newParent.AddChild(this);
        }
        else
        {
            parent.RemoveChild(_modalScene);
            _modalScene.Free();
            _modalScene = null;
        }
    }

    private void OnCancelButtonPressed()
    {
        Hide();
    }
}
