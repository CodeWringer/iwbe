using StoreSystem;
using System.Drawing;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents styling for text/font, such as family, size, boldness, strike-through, etc. 
    /// </summary>
    public class FontStyle
    {
        public Watchable<float> SizeWatchable = new Watchable<float>();
        /// <summary>
        /// Size of the text. Unit: pixels?
        /// </summary>
        public float Size
        {
            get => SizeWatchable.Value;
            set => SizeWatchable.Value = value;
        }

        public Watchable<bool> BoldWatchable = new Watchable<bool>();
        /// <summary>
        /// If true, draw bold letters. 
        /// </summary>
        public bool Bold
        {
            get => BoldWatchable.Value;
            set => BoldWatchable.Value = value;
        }

        public Watchable<bool> ItalicWatchable = new Watchable<bool>();
        /// <summary>
        /// If true, draw italic letters. 
        /// </summary>
        public bool Italic
        {
            get => ItalicWatchable.Value;
            set => ItalicWatchable.Value = value;
        }

        public Watchable<bool> StrikeThroughWatchable = new Watchable<bool>();
        /// <summary>
        /// If true, draw text as strike-through. 
        /// </summary>
        public bool StrikeThrough
        {
            get => StrikeThroughWatchable.Value;
            set => StrikeThroughWatchable.Value = value;
        }

        public Watchable<bool> UnderlineWatchable = new Watchable<bool>();
        /// <summary>
        /// If true, draw text underlined. 
        /// </summary>
        public bool Underline
        {
            get => UnderlineWatchable.Value;
            set => UnderlineWatchable.Value = value;
        }

        public Watchable<Color> ColorWatchable = new Watchable<Color>();
        /// <summary>
        /// Color to draw text with. 
        /// </summary>
        public Color Color
        {
            get => ColorWatchable.Value;
            set => ColorWatchable.Value = value;
        }

        public Watchable<string> FontFamilyWatchable = new Watchable<string>();
        /// <summary>
        /// A font family name. 
        /// </summary>
        public string FontFamily
        {
            get => FontFamilyWatchable.Value;
            set => FontFamilyWatchable.Value = value;
        }
    }
}