using StoreSystem;
using System.Numerics;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents the base class for canvas objects. 
    /// Provides some common functionality. 
    /// </summary>
    public abstract class CanvasDrawable : ITaggable
    {
        public Watchable<float> MinZoomWatchable = new Watchable<float>();
        /// <summary>
        /// Multiplier, defining the minimum zoom to display this object at. 
        /// If <= 0.0, is not considered relevant. 
        /// </summary>
        public float MinZoom
        {
            get => MinZoomWatchable.Value;
            set => MinZoomWatchable.Value = value;
        }

        public Watchable<float> MaxZoomWatchable = new Watchable<float>();
        /// <summary>
        /// Multiplier, defining the maximum zoom to display this object at. 
        /// If <= 0.0, is not considered relevant. 
        /// </summary>
        public float MaxZoom
        {
            get => MaxZoomWatchable.Value;
            set => MaxZoomWatchable.Value = value;
        }

        public Watchable<Vector2> PositionWatchable = new Watchable<Vector2>();
        /// <summary>
        /// Position on canvas, in x and y coordinates. 
        /// </summary>
        public Vector2 Position
        {
            get => PositionWatchable.Value;
            set => PositionWatchable.Value = value;
        }

        public CanvasDrawable()
        {
        }

        public CanvasDrawable(Vector2 position, float minZoom = -1.0f, float maxZoom = -1.0f)
        {
            this.Position = position;
            this.MinZoom = minZoom;
            this.MaxZoom = maxZoom;
        }
    }
}