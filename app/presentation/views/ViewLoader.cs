using Godot;
using System;
using System.Collections.Generic;

namespace iwbe.presentation.views
{
    /// <summary>
    /// Loads and serves scenes from the resources. Caches loaded scenes. 
    /// </summary>
    public static class ViewLoader
    {
        /// <summary>
        /// Dictionary of registered workspaces and their resource. 
        /// </summary>
        private static Dictionary<String, PackedScene> _scenes = new Dictionary<string, PackedScene>();

        /// <summary>
        /// Loads a scene at the given path, relative to the resources directory. The provided path must not contain "res://"! 
        /// </summary>
        /// <param name="path">Path of the scene to load. Must not contain "res://"! </param>
        /// <returns></returns>
        public static PackedScene Load(string path)
        {
            if (!_scenes.ContainsKey(path))
            {
                var packedScene = ResourceLoader.Load<PackedScene>("res://" + path);
                _scenes.Add(path, packedScene);
            }
            return _scenes[path];
        }
    }
}
