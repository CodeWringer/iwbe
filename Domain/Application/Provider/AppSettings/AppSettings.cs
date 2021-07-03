using Iwbe.Domain.Model;
using System.Collections.Generic;

namespace Iwbe.Domain.Provider
{

    /// <summary>
    /// Represents the application's settings. This should only be a transient object, for use in reading/writing app settings from/to disk. 
    /// Not user-specific. 
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// The window width, in pixels, to set at application launch, if possible. 
        /// </summary>
        public int WindowWidthPreferred { get; set; }

        /// <summary>
        /// The window height, in pixels, to set at application launch, if possible. 
        /// </summary>
        public int WindowHeightPreferred { get; set; }

        /// <summary>
        /// Pinned projects. 
        /// Allows only unique values. 
        /// </summary>
        public IEnumerable<ProjectId> PinnedProjects { get; set; }

        /// <summary>
        /// Recently opened projects. 
        /// Allows only unique values. 
        /// </summary>
        public IEnumerable<ProjectId> RecentProjects { get; set; }

        public AppSettings()
        {
            WindowWidthPreferred = 1280;
            WindowHeightPreferred = 720;
            PinnedProjects = new List<ProjectId>();
            RecentProjects = new List<ProjectId>();
        }
    }
}