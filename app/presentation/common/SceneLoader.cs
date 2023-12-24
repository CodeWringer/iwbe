using Godot;
using System.Collections.Generic;

namespace iwbe.presentation.common
{
    /// <summary>
    /// Handles loading packed scenes, which can be added as nodes to the scene tree. 
    /// 
    /// <br></br>
    /// 
    /// This is a static singleton, to prevent loading the same asset multiple times and to better 
    /// control file access. 
    /// </summary>
    public static class SceneLoader
    {
        private static System.Text.RegularExpressions.Regex _regExResourceUrl = new System.Text.RegularExpressions.Regex("[rR][eE][sS]://");

        /// <summary>
        /// Cache of loaded scenes. 
        /// </summary>
        private static Dictionary<string, PackedScene> _loaded = new Dictionary<string, PackedScene>();
        /// <summary>
        /// Cache of loaded scenes. 
        /// </summary>
        public static IEnumerable<KeyValuePair<string, PackedScene>> LoadedScenes => _loaded;

        /// <summary>
        /// Loads the scene located via the given resource URL. 
        /// </summary>
        /// <param name="resourceUrl">Resource relative URL. </param>
        public static PackedScene Load(string resourceUrl)
        {
            string sanitizedUrl = SanitizeUrl(resourceUrl);

            if (_loaded.ContainsKey(sanitizedUrl) == false)
            {
                PackedScene packedScene = ResourceLoader.Load<PackedScene>("res://" + sanitizedUrl);
                _loaded.Add(sanitizedUrl, packedScene);
            }

            return _loaded[sanitizedUrl];
        }

        /// <summary>
        /// Returns the given resource relative URL without the `res://` protocol identifier. 
        /// </summary>
        /// <param name="url">The URL to sanitize. </param>
        /// <returns>The sanitized URL. </returns>
        public static string SanitizeUrl(string url)
        {
            var match = _regExResourceUrl.Match(url);
            if (match.Success) { 
                return url.Substring(match.Length);
            }

            return url;
        }
    }
}
