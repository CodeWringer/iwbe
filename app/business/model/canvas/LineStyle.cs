using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Defines styling for a line, such as color, dash type and width. 
    /// </summary>
    public class LineStyle
    {
        /// <summary>
        /// The line's color. 
        /// </summary>
        public Color Color;

        /// <summary>
        /// The line's dash style. 
        /// </summary>
        public DashTypes DashType;

        private float _dashInterval;
        /// <summary>
        /// If not DashType == DashTypes.None, the distance between dashes or dots. 
        /// Min: 0.0f
        /// </summary>
        public float DashInterval
        {
            get { return this._dashInterval; }
            set { this._dashInterval = Mathf.Max(0.0f, value); }
        }

        private float _width;
        /// <summary>
        /// Width of the line or dashes/dots. 
        /// Min: 0.0f
        /// </summary>
        public float Width
        {
            get { return this._width; }
            set { this._width = Mathf.Max(0.0f, value); }
        }
    }

    /// <summary>
    /// Enum of available dash types for lines. 
    /// TODO: Determine more generic solution to draw arbitrary shapes. 
    /// </summary>
    public enum DashTypes
    {
        /// <summary>
        /// No dash.
        /// </summary>
        None,
        /// <summary>
        /// Dashes. 
        /// </summary>
        Dashed,
        /// <summary>
        /// Dots. 
        /// </summary>
        Dotted,
        /// <summary>
        /// Alternating between dashes and dots. 
        /// </summary>
        DashedDotted,
    }
}
