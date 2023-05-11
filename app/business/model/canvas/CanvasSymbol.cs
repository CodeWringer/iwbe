using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a bitmap to draw on the canvas. 
    /// </summary>
    public class CanvasSymbol : CanvasDrawable
    {
        /// <summary>
        /// Full project-relative file path to an image on disk. 
        /// </summary>
        public string Path;

        /// <summary>
        /// 
        /// </summary>
        public Rect2 Rect;

        public new Vector2 Position
        {
            get { return this.Rect.Position; }
            set { this.Rect.Position = value; }
        }
    }
}
