using Godot;

namespace iwbe.business.model
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

        /// <summary>
        /// The symbol's size at neutral zoom level. 
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// The symbol's location at neutral zoom level. 
        /// </summary>
        public Vector2 Position;
    }
}
