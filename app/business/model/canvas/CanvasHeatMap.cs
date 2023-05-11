using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a collection of points that, together, form a heat map on canvas. 
    /// </summary>
    public class CanvasHeatMap : CanvasDrawable
    {
        /// <summary>
        /// Colors to use for the heat map. 
        /// </summary>
        public List<ColorStop> ColorStops;

        /// <summary>
        /// A list of points with a radius and intensity. 
        /// </summary>
        public List<CanvasHeatSource> HeatSources;
    }
}