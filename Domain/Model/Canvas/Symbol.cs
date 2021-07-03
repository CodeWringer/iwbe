using StoreSystem;
using System.Drawing;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a symbol, based on a loaded bitmap. 
    /// </summary>
    public class Symbol
    {
        public Watchable<string> PathWatchable = new Watchable<string>();
        /// <summary>
        /// Full project-relative file path to the image on disk. 
        /// </summary>
        public string Path
        {
            get => PathWatchable.Value;
            set => PathWatchable.Value = value;
        }

        public Watchable<Color> ColorWatchable = new Watchable<Color>();
        /// <summary>
        /// Overrides the image color. 
        /// </summary>
        public Color Color
        {
            get => ColorWatchable.Value;
            set => ColorWatchable.Value = value;
        }
    }
}