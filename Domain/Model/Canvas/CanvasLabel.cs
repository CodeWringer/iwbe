using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a label on canvas. 
    /// </summary>
    public class CanvasLabel : CanvasDrawable
    {
        public Watchable<string> TextWatchable = new Watchable<string>();
        /// <summary>
        /// The text to display for the label. 
        /// </summary>
        public string Text
        {
            get => TextWatchable.Value;
            set => TextWatchable.Value = value;
        }

        public Watchable<FontStyle> StyleWatchable = new Watchable<FontStyle>();
        /// <summary>
        /// Styling of the label text. 
        /// </summary>
        public FontStyle Style
        {
            get => StyleWatchable.Value;
            set => StyleWatchable.Value = value;
        }
    }
}