using System;

namespace Iwbe.Domain.Model
{

    /// <summary>
    /// Represents an @-reference inline the markdown content of an article. 
    /// </summary>
    public class InlineAtReference : IInlineContent
    {
        /// <summary>
        /// ID of the referenced article. 
        /// </summary>
        public Guid ArticleId;

        /// <summary>
        /// Index of the character in the content where this object is to be rendered. 
        /// </summary>
        public long Position;

        /// <summary>
        /// The text to display in the article content. 
        /// </summary>
        public string DisplayText;

        /// <summary>
        /// Name of a header in the referenced article. If not null, this is the header that should be focused 
        /// when the article is opened via this reference. 
        /// </summary>
        public string Anchor;

        /// <summary>
        /// Styling of the displayed text. 
        /// </summary>
        public FontStyle Style;
    }
}