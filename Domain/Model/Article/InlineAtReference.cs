using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{

    /// <summary>
    /// Represents an @-reference inline the markdown content of an article. 
    /// </summary>
    public class InlineAtReference : IInlineContent
    {
        public Watchable<Guid> ArticleIdWatchable = new Watchable<Guid>();
        /// <summary>
        /// ID of the referenced article. 
        /// </summary>
        public Guid ArticleId
        {
            get => ArticleIdWatchable.Value;
            set => ArticleIdWatchable.Value = value;
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

        public Watchable<string> DisplayTextWatchable = new Watchable<string>();
        /// <summary>
        /// The text to display in the article content. 
        /// </summary>
        public string DisplayText
        {
            get => DisplayTextWatchable.Value;
            set => DisplayTextWatchable.Value = value;
        }

        public Watchable<string> AnchorWatchable = new Watchable<string>();
        /// <summary>
        /// Name of a header in the referenced article. If not null, this is the header that should be focused 
        /// when the article is opened via this reference. 
        /// </summary>
        public string Anchor
        {
            get => AnchorWatchable.Value;
            set => AnchorWatchable.Value = value;
        }

        public Watchable<FontStyle> StyleWatchable = new Watchable<FontStyle>();
        /// <summary>
        /// Styling of the displayed text. 
        /// </summary>
        public FontStyle Style
        {
            get => StyleWatchable.Value;
            set => StyleWatchable.Value = value;
        }
    }
}