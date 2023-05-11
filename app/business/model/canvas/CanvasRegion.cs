using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a polygon on canvas. 
    /// </summary>
    public class CanvasRegion : CanvasDrawable
    {
        /// <summary>
        /// Determines how the polygon edges will be rendered. 
        /// </summary>
        public LineStyle BorderStyle;

        /// <summary>
        /// Determines how the interior of the polygon will be rendered. 
        /// </summary>
        public FillStyle FillStyle;

        /// <summary>
        /// Determines how overlaps with other polygons will be rendered. 
        /// </summary>
        public FillStyle OverlapStyle;

        /// <summary>
        /// The polygon that represents this object on canvas. 
        /// </summary>
        public Polygon2D Polygon;
    }
}
