using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a collection of points that, together, form a heat map on canvas. 
    /// </summary>
    public class CanvasHeatMap : CanvasDrawable
    {
        public WatchableCollection<ColorStop> ContentWatchable = new WatchableCollection<ColorStop>();
        /// <summary>
        /// Colors to use for the heat map. 
        /// </summary>
        public ObservableList<ColorStop> ColorStops
        {
            get => ContentWatchable.Collection;
            set => ContentWatchable.Collection = value;
        }

        public WatchableCollection<CanvasHeatSource> HeatSourcesWatchable = new WatchableCollection<CanvasHeatSource>();
        /// <summary>
        /// A list of points with a radius and intensity. 
        /// </summary>
        public ObservableList<CanvasHeatSource> HeatSources
        {
            get => HeatSourcesWatchable.Collection;
            set => HeatSourcesWatchable.Collection = value;
        }
    }
}