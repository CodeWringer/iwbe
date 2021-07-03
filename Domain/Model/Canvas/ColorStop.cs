using StoreSystem;
using System;
using System.Drawing;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Defines a color stop. 
    /// </summary>
    public class ColorStop
    {
        public Watchable<Color> ColorWatchable = new Watchable<Color>();
        /// <summary>
        /// The color at full strength of the color stop. 
        /// </summary>
        public Color Color
        {
            get => ColorWatchable.Value;
            set => ColorWatchable.Value = value;
        }

        public Watchable<float> PositionWatchable = new Watchable<float>();
        /// <summary>
        /// From 0.0 to 1.0, where the color stop is at full strength. 
        /// </summary>
        public float Position
        {
            get => PositionWatchable.Value;
            set => PositionWatchable.Value = value;
        }
    }
}