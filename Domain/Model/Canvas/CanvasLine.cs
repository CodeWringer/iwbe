using StoreSystem;
using System.Numerics;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a line between two points, on canvas. 
    /// </summary>
    public class CanvasLine : CanvasDrawable
    {
        public Watchable<Vector2> StartWatchable = new Watchable<Vector2>();
        /// <summary>
        /// Point where the line begins. 
        /// </summary>
        public Vector2 Start
        {
            get => StartWatchable.Value;
            set => StartWatchable.Value = value;
        }

        public Watchable<Vector2> EndWatchable = new Watchable<Vector2>();
        /// <summary>
        /// Point where the line ends. 
        /// </summary>
        public Vector2 End
        {
            get => EndWatchable.Value;
            set => EndWatchable.Value = value;
        }

        public Watchable<LineStyle> StyleWatchable = new Watchable<LineStyle>();
        /// <summary>
        /// Determines how to draw the line. 
        /// </summary>
        public LineStyle Style
        {
            get => StyleWatchable.Value;
            set => StyleWatchable.Value = value;
        }
    }
}