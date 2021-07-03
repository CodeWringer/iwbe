using System.Drawing;
using System.Numerics;

namespace Iwbe.Domain.Model
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
        public Rectangle Rect;

        public new Vector2 Position
        {
            get { return new Vector2(Rect.Location.X, Rect.Location.Y); }
            set { Rect.Location = new Point((int)value.X, (int)value.Y); }
        }
    }
}