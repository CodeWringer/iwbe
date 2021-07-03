using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents article content, specific to a locale. 
    /// </summary>
    public class LocalizedContent
    {
        /// <summary>
        /// The associated language. E. g. "en", "en-us", "de", "de-de", etc.
        /// </summary>
        public string Language;

        /// <summary>
        /// Represents article content. 
        /// TODO: Determine if a more memory-friendly/performant way of storing this than a single, big string is possible. 
        /// </summary>
        public string Content;

        /// <summary>
        /// List of inline images. 
        /// </summary>
        public List<InlineImage> Images;

        /// <summary>
        /// List of inline fonts. 
        /// </summary>
        public List<InlineFont> Fonts;

        /// <summary>
        /// List of @-References. 
        /// </summary>
        public List<InlineAtReference> AtReferences;
    }
}