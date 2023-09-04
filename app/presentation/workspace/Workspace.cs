using System;

namespace iwbe.presentation.workspace
{
    /// <summary>
    /// Represents a workspace. 
    /// </summary>
    public interface IWorkspace
    {
        /// <summary>
        /// ID of the workspace. 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Name of the workspace. 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Relative resource url of the view within resources directory. 
        /// </summary>
        public string ResourceUrlView { get; }

        /// <summary>
        /// Relative resource url of the icon image within resources directory. 
        /// </summary>
        public string ResourceUrlIcon { get; }
    }
}
