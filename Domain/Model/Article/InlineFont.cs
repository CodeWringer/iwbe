using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a font inline the markdown content of an article. 
    /// </summary>
    public class InlineFont : IInlineContent
    {
        public Watchable<long> StartWatchable = new Watchable<long>();
        /// <summary>
        /// Index of the character in the content where this font begins. 
        /// </summary>
        public long Start
        {
            get => StartWatchable.Value;
            set => StartWatchable.Value = value;
        }

        public Watchable<long> EndWatchable = new Watchable<long>();
        /// <summary>
        /// Index of the character in the content where this font begins. 
        /// </summary>
        public long End
        {
            get => EndWatchable.Value;
            set => EndWatchable.Value = value;
        }

        public Watchable<FontStyle> StyleWatchable = new Watchable<FontStyle>();
        /// <summary>
        /// Styling of size, color, boldness, etc. 
        /// </summary>
        public FontStyle Style
        {
            get => StyleWatchable.Value;
            set => StyleWatchable.Value = value;
        }
    }
}