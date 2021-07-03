using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a polygon on canvas. 
    /// </summary>
    public class CanvasRegion : CanvasDrawable
    {
        public Watchable<LineStyle> BorderStyleWatchable = new Watchable<LineStyle>();
        /// <summary>
        /// Determines how the polygon edges will be rendered. 
        /// </summary>
        public LineStyle BorderStyle
        {
            get => BorderStyleWatchable.Value;
            set => BorderStyleWatchable.Value = value;
        }

        public Watchable<FillStyle> FillStyleWatchable = new Watchable<FillStyle>();
        /// <summary>
        /// Determines how the interior of the polygon will be rendered. 
        /// </summary>
        public FillStyle FillStyle
        {
            get => FillStyleWatchable.Value;
            set => FillStyleWatchable.Value = value;
        }

        public Watchable<FillStyle> OverlapStyleWatchable = new Watchable<FillStyle>();
        /// <summary>
        /// Determines how overlaps with other polygons will be rendered. 
        /// </summary>
        public FillStyle OverlapStyle
        {
            get => OverlapStyleWatchable.Value;
            set => OverlapStyleWatchable.Value = value;
        }

        /// <summary>
        /// The polygon that represents this object on canvas. 
        /// </summary>
        //public Polygon Polygon;
    }
}