using System.Drawing;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a symbol, based on a loaded bitmap. 
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// Full project-relative file path to the image on disk. 
        /// </summary>
        public string Path;

        /// <summary>
        /// Overrides the image color. 
        /// </summary>
        public Color Color;
    }
}