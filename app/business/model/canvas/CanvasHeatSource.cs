using Godot;

namespace iwbe.business.model
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
            get { return this._radius; }
            set { this._radius = Mathf.Max(0.0f, value); }
        }

        private float _intensity;
        /// <summary>
        /// Intensity of the heat source. 
        /// 0.0f - 1.0f
        /// </summary>
        public float Intensity
        {
            get { return this._intensity; }
            set { this._intensity = Mathf.Clamp(value, 0.0f, 1.0f); }
        }
    }
}