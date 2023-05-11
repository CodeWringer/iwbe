using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents styling for text/font, such as family, size, boldness, strike-through, etc. 
    /// </summary>
    public class FontStyle
    {
        /// <summary>
        /// Size of the text. Unit: pixels?
        /// </summary>
        public float Size;

        /// <summary>
        /// If true, draw bold letters. 
        /// </summary>
        public bool Bold;

        /// <summary>
        /// If true, draw italic letters. 
        /// </summary>
        public bool Italic;

        /// <summary>
        /// If true, draw text as strike-through. 
        /// </summary>
        public bool StrikeThrough;

        /// <summary>
        /// If true, draw text underlined. 
        /// </summary>
        public bool Underline;

        /// <summary>
        /// Color to draw text with. 
        /// </summary>
        public Color Color;

        /// <summary>
        /// A font family name. 
        /// </summary>
        public string FontFamily;
    }
}