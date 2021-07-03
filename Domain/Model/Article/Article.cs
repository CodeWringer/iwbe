using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents an article definition. 
    /// </summary>
    public class Article : IEquatable<Article>, ITaggable
    {
        /// <summary>
        /// ID of the article. 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Display name of the article. 
        /// </summary>
        public string Title;

        /// <summary>
        /// The number of words the article content contains. 
        /// </summary>
        public long WordCount;

        /// <summary>
        /// The type of thing this article describes. E. g. "Character", "Nation", "Location", "Item", etc. 
        /// </summary>
        public string Type;

        /// <summary>
        /// The actual content of the article. 
        /// </summary>
        public List<LocalizedContent> Content;

        /// <summary>
        /// List of prominent content, which should be displayed in its own, easily accessible block. 
        /// </summary>
        public List<LocalizedContent> ProminentContent;

        public Article(Guid id)
        {
            this.Content = new List<LocalizedContent>();
            this.ProminentContent = new List<LocalizedContent>();

            this.Id = id;
        }

        public bool Equals([AllowNull] Article other)
        {
            if (other == null)
                return false;
            else
                return this.Id == other.Id;
        }
    }
}