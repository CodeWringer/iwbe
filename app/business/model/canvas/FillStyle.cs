using Godot;
using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Defines a fill style. 
    /// </summary>
    public class FillStyle
    {
        /// <summary>
        /// A list of color stops. 
        /// </summary>
        public List<ColorStop> Colors;

        /// <summary>
        /// Type of hatching. 
        /// </summary>
        public HatchingTypes HatchingType;

        private float _hatchInterval;
        /// <summary>
        /// If not HatchingType == HatchingType.None, the distance between lines. 
        /// Min: 0.0f
        /// </summary>
        public float HatchingInterval
        {
            get { return this._hatchInterval; }
            set { this._hatchInterval = Mathf.Max(0.0f, value); }
        }

        private float _hatchingWidth;
        /// <summary>
        /// Width of the hatching lines. 
        /// Min: 0.0f
        /// </summary>
        public float HatchingWidth
        {
            get { return this._hatchingWidth; }
            set { this._hatchingWidth = Mathf.Max(0.0f, value); }
        }
    }

    /// <summary>
    /// Enum of available hatching types. 
    /// TODO: Determine more generic solution to draw arbitrary shapes. 
    /// </summary>
    public enum HatchingTypes
    {
        None,
        Lines,
        CrossedLines,
    }
}