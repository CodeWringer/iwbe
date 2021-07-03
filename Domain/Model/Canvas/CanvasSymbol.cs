using StoreSystem;
using System.Drawing;
using System.Numerics;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a bitmap to draw on the canvas. 
    /// </summary>
    public class CanvasSymbol : CanvasDrawable
    {
        public Watchable<string> PathWatchable = new Watchable<string>();
        /// <summary>
        /// Full project-relative file path to an image on disk. 
        /// </summary>
        public string Path
        {
            get => PathWatchable.Value;
            set => PathWatchable.Value = value;
        }

        public Watchable<Rectangle> RectWatchable = new Watchable<Rectangle>();
        /// <summary>
        /// 
        /// </summary>
        public Rectangle Rect
        {
            get => RectWatchable.Value;
            set => RectWatchable.Value = value;
        }
    }
}