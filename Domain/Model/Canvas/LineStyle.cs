using StoreSystem;
using System;
using System.Drawing;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Defines styling for a line, such as color, dash type and width. 
    /// </summary>
    public class LineStyle
    {
        public Watchable<Color> ColorWatchable = new Watchable<Color>();
        /// <summary>
        /// The line's color. 
        /// </summary>
        public Color Color
        {
            get => ColorWatchable.Value;
            set => ColorWatchable.Value = value;
        }

        public Watchable<DashTypes> DashTypeWatchable = new Watchable<DashTypes>();
        /// <summary>
        /// The line's dash style. 
        /// </summary>
        public DashTypes DashType
        {
            get => DashTypeWatchable.Value;
            set => DashTypeWatchable.Value = value;
        }

        public Watchable<float> DashIntervalWatchable = new Watchable<float>();
        /// <summary>
        /// If not DashType == DashTypes.None, the distance between dashes or dots. 
        /// Min: 0.0f
        /// </summary>
        public float DashInterval
        {
            get => DashIntervalWatchable.Value;
            set => DashIntervalWatchable.Value = value;
        }

        public Watchable<float> WidthWatchable = new Watchable<float>();
        /// <summary>
        /// Width of the line or dashes/dots. 
        /// Min: 0.0f
        /// </summary>
        public float Width
        {
            get => WidthWatchable.Value;
            set => WidthWatchable.Value = value;
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