namespace iwbe.business.model
{
    /// <summary>
    /// Represents a font inline the markdown content of an article. 
    /// </summary>
    public class InlineFont : IInlineContent
    {
        /// <summary>
        /// Index of the character in the content where this font begins. 
        /// </summary>
        public long Start;

        /// <summary>
        /// Index of the character in the content where this font begins. 
        /// </summary>
        public long End;

        /// <summary>
        /// Styling of size, color, boldness, etc. 
        /// </summary>
        public FontStyle Style;
    }
}