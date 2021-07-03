using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Defines a fill style. 
    /// </summary>
    public class FillStyle
    {
        public WatchableCollection<ColorStop> ColorsWatchable = new WatchableCollection<ColorStop>();
        /// <summary>
        /// A list of color stops. 
        /// </summary>
        public ObservableList<ColorStop> Colors
        {
            get => ColorsWatchable.Collection;
            set => ColorsWatchable.Collection = value;
        }

        public Watchable<HatchingTypes> HatchingTypeWatchable = new Watchable<HatchingTypes>();
        /// <summary>
        /// Type of hatching. 
        /// </summary>
        public HatchingTypes HatchingType
        {
            get => HatchingTypeWatchable.Value;
            set => HatchingTypeWatchable.Value = value;
        }

        public Watchable<float> HatchingIntervalWatchable = new Watchable<float>();
        /// <summary>
        /// If not HatchingType == HatchingType.None, the distance between lines. 
        /// Min: 0.0f
        /// </summary>
        public float HatchingInterval
        {
            get => HatchingIntervalWatchable.Value;
            set => HatchingIntervalWatchable.Value = value;
        }

        public Watchable<float> HatchingWidthWatchable = new Watchable<float>();
        /// <summary>
        /// Width of the hatching lines. 
        /// Min: 0.0f
        /// </summary>
        public float HatchingWidth
        {
            get => HatchingWidthWatchable.Value;
            set => HatchingWidthWatchable.Value = value;
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