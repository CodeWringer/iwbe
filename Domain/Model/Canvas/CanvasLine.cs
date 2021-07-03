using System.Numerics;

namespace Iwbe.Domain.Model
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
            get { return Position; }
            set { Position = value; }
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