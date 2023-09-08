using Godot;
using System;

namespace iwbe.presentation.navigation
{
    /// <summary>
    /// Handles all navigation. Used to activate workspaces and dialogs and to navigate within them. 
    /// </summary>
    public class ViewNavigator
    {
        /// <summary>
        /// The node beneath which the currently active workspace is placed. 
        /// </summary>
        private Control _mainViewPort;

        /// <summary>
        /// The root node. 
        /// </summary>
        private Main _main;

        public ViewNavigator(Main mainNode,  Control mainViewPort)
        {
            _main = mainNode;
            _mainViewPort = mainViewPort;
        }

        /// <summary>
        /// Replaces the current view with the given view. 
        /// </summary>
        /// <param name="viewPath">Name of the workspace to activate. </param>
        /// <exception cref="Exception">Thrown, if no workspace with the given name exists. </exception>
        public void NavigateTo(string viewPath)
        {
            // TODO
        }

        /// <summary>
        /// Un-sets the current view, by removing any children from the main view port node. 
        /// </summary>
        private void ClearViewPort()
        {
            var toRemove = _mainViewPort.GetChildren();
            for (int i = toRemove.Count - 1; i >= 0; i--)
            {
                _mainViewPort.RemoveChild(toRemove[i]);
            }
        }

        /// <summary>
        /// Sets the given view to be active in the main view port. 
        /// </summary>
        /// <param name="view"></param>
        private void SetViewPort(Control view)
        {
            ClearViewPort();

            // Ensure the given view does not already have a parent. 
            var parent = view.GetParent();
            if (parent != null)
            {
                parent.RemoveChild(view);
            }

            // Add the given view to the scene. 
            _mainViewPort.AddChild(view);
        }
    }
}
