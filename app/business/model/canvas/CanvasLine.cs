using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a line between two points, on canvas. 
    /// </summary>
    public class CanvasLine : CanvasDrawable
    {
        /// <summary>
        /// Point where the line begins. 
        /// </summary>
        public Vector2 Start
        {
            get { return this.Position; }
            set { this.Position = value; }
        }

        /// <summary>
        /// Point where the line ends. 
        /// </summary>
        public Vector2 End;

        /// <summary>
        /// Determines how to draw the line. 
        /// </summary>
        public LineStyle Style;
    }
}