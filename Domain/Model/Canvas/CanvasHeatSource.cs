using System;
using System.Numerics;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a heat map source on canvas, relative to an associated heat map. 
    /// </summary>
    public class CanvasHeatSource
    {
        /// <summary>
        /// Position on canvas, relative to parent heat map. 
        /// </summary>
        public Vector2 Position;

        private float _radius;
        /// <summary>
        /// Radius in pixels. 
        /// Min: 0.0f
        /// </summary>
        public float Radius
        {
            get { return _radius; }
            set { _radius = Math.Max(0.0f, value); }
        }

        private float _intensity;
        /// <summary>
        /// Intensity of the heat source. 
        /// 0.0f - 1.0f
        /// </summary>
        public float Intensity
        {
            get { return _intensity; }
            set { _intensity = Math.Clamp(value, 0.0f, 1.0f); }
        }
    }
}