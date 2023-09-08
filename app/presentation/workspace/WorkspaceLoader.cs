using Godot;
using iwbe.presentation.views;
using System.Collections.Generic;
using System.Linq;

namespace iwbe.presentation.workspace
{
    /// <summary>
    /// Handles loading workspaces as resources, which can be added as nodes to the scene tree. 
    /// </summary>
    internal class WorkspaceLoader
    {
        /// <summary>
        /// Dictionary of registered workspaces and their resource. 
        /// </summary>
        private Dictionary<IWorkspace, PackedScene> _workspaces;
        /// <summary>
        /// Registered workspaces and their resource. 
        /// Note that the resources are initially null. Call the "Load" method to populate the list of resources. 
        /// </summary>
        internal IEnumerable<KeyValuePair<IWorkspace, PackedScene>> Workspaces => _workspaces;

        internal WorkspaceLoader()
        {
            _workspaces = new Dictionary<IWorkspace, PackedScene>();
        }

        /// <summary>
        /// Loads the resources of all registered workspaces. 
        /// 
        /// <br></br>
        /// 
        /// Note that all resource urls are expected to be relative to the resources directory. 
        /// Therefore, they must not start with "res://", as that part is implied. 
        /// </summary>
        internal void Load()
        {
            foreach (var kv in _workspaces)
            {
                var packedScene = ViewLoader.Load(kv.Key.ResourceUrlView);
                _workspaces[kv.Key] = packedScene;
            }
        }

        /// <summary>
        /// Registers the given Workspace. 
        /// </summary>
        /// <param name="workspace"></param>
        internal void Register(IWorkspace workspace)
        {
            if (_workspaces.Keys.Any(it => it.Id == workspace.Id) == false)
            {
                _workspaces.Add(workspace, null);
            }
        }
    }
}
