using StoreSystem;
using System;

namespace Iwbe.Presentation
{
    public class ViewState
    {
        public Watchable<WorkspaceTypes> ActiveWorkspaceWatchable;
        public WorkspaceTypes ActiveWorkspace
        {
            get => ActiveWorkspaceWatchable.Value;
            set => ActiveWorkspaceWatchable.Value = value;
        }

        public ViewState()
        {
        }
    }
}