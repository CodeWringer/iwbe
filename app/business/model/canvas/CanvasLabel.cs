namespace iwbe.business.model
{
    /// <summary>
    /// Represents a label on canvas. 
    /// </summary>
    public class CanvasLabel : CanvasDrawable
    {
        /// <summary>
        /// The text to display for the label. 
        /// </summary>
        public string Text;

        /// <summary>
        /// Styling of the label text. 
        /// </summary>
        public FontStyle Style;
    }
}
