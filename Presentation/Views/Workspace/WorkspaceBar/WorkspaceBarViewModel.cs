using System;
using Iwbe.Domain;

namespace Iwbe.Presentation
{
    public class WorkspaceBarViewModel : ViewModelBase
    {
        private bool _workspacesEnabled;
        public bool WorkspacesEnabled
        {
            get { return _workspacesEnabled; }
            set
            {
                this._workspacesEnabled = value;
                this.OnPropertyChanged();
            }
        }

        public WorkspaceBarViewModel()
        {
            var state = IwbeApplication.State.ProjectState;

            state.ActiveProject.PropertyChanged += (sender, e) => { this.WorkspacesEnabled = state.ActiveProject.Value != null; };
        }

        public void SetActiveWorkspace(WorkspaceTypes workspace)
        {
            ((App)App.Current).ViewState.ActiveWorkspace.Value = workspace;
        }
    }
}