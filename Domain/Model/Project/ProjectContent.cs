using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents the content (articles, canvas objects, etc.) of a project. 
    /// </summary>
    public class ProjectContent
    {
        /// <summary>
        /// List of project-relative file paths of article definitions. 
        /// </summary>
        public List<string> Writing;

        /// <summary>
        /// List of project-relative file paths of canvas objects. 
        /// </summary>
        public List<string> Canvas;

        /// <summary>
        /// List of project-relative file paths of hierarchy definitions. 
        /// </summary>
        public List<string> Hierarchies;

        /// <summary>
        /// List of project-relative file paths of timeline definitions. 
        /// </summary>
        public List<string> Timeline;
    }
}