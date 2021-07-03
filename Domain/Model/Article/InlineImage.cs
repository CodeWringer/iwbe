using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents an image inline the markdown content of an article. 
    /// </summary>
    public class InlineImage : IInlineContent
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

        public Watchable<long> PositionWatchable = new Watchable<long>();
        /// <summary>
        /// Index of the character in the content where this object is to be rendered. 
        /// </summary>
        public long Position
        {
            get => PositionWatchable.Value;
            set => PositionWatchable.Value = value;
        }

        public Watchable<float> MaxHeightWatchable = new Watchable<float>();
        /// <summary>
        /// Maximum height in the text. 
        /// Min: 0.0f
        /// </summary>
        public float MaxHeight
        {
            get => MaxHeightWatchable.Value;
            set => MaxHeightWatchable.Value = Math.Max(0.0f, value);
        }

        public Watchable<float> MaxWidthWatchable = new Watchable<float>();
        /// <summary>
        /// Maximum width in the text. 
        /// Min: 0.0f
        /// </summary>
        public float MaxWidth
        {
            get => MaxWidthWatchable.Value;
            set => MaxWidthWatchable.Value = Math.Max(0.0f, value);
        }
    }
}