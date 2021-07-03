using System;

namespace Iwbe.Domain.Model
{

    /// <summary>
    /// Represents an image inline the markdown content of an article. 
    /// </summary>
    public class InlineImage : IInlineContent
    {
        /// <summary>
        /// Full project-relative file path to the image on disk. 
        /// </summary>
        public string Path;

        /// <summary>
        /// Index of the character in the content where this object is to be rendered. 
        /// </summary>
        public long Position;

        private float _maxHeight;
        /// <summary>
        /// Maximum height in the text. 
        /// Min: 0.0f
        /// </summary>
        public float MaxHeight
        {
            get { return _maxHeight; }
            set { _maxHeight = Math.Max(0.0f, value); }
        }

        private float _maxWidth;
        /// <summary>
        /// Maximum width in the text. 
        /// Min: 0.0f
        /// </summary>
        public float MaxWidth
        {
            get { return _maxWidth; }
            set { _maxWidth = Math.Max(0.0f, value); }
        }
    }
}