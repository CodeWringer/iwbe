using StoreSystem;
using System;
using System.Numerics;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a heat map source on canvas, relative to an associated heat map. 
    /// </summary>
    public class CanvasHeatSource
    {
        public Watchable<Vector2> PositionWatchable = new Watchable<Vector2>();
        /// <summary>
        /// Position on canvas, relative to parent heat map. 
        /// </summary>
        public Vector2 Position
        {
            get => PositionWatchable.Value;
            set => PositionWatchable.Value = value;
        }

        public Watchable<float> RadiusWatchable = new Watchable<float>();
        /// <summary>
        /// Radius in pixels. 
        /// Min: 0.0f
        /// </summary>
        public float Radius
        {
            get => RadiusWatchable.Value;
            set => RadiusWatchable.Value = value;
        }

        public Watchable<float> IntensityWatchable = new Watchable<float>();
        /// <summary>
        /// Intensity of the heat source. 
        /// 0.0f - 1.0f
        /// </summary>
        public float Intensity
        {
            get => IntensityWatchable.Value;
            set => IntensityWatchable.Value = value;
        }
    }
}