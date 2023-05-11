using System;
using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents article content, specific to a locale. 
    /// </summary>
    public class LocalizedContent
    {
        /// <summary>
        /// The associated language. E. g. "en", "en-us", "de", "de-de", "FLORB" etc.
        /// </summary>
        public string Language;

        /// <summary>
        /// Represents the localized content. 
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