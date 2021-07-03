using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents the assets (images, fonts, etc.) of a project. 
    /// </summary>
    public class ProjectAssets
    {
        /// <summary>
        /// List of full file paths of image files. 
        /// </summary>
        public List<string> Images;

        /// <summary>
        /// List of full file paths of font files. 
        /// </summary>
        public List<string> Fonts;
    }
}