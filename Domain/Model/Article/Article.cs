using StoreSystem;
using System;
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

        public Watchable<string> TitleWatchable = new Watchable<string>();
        /// <summary>
        /// Display name of the article. 
        /// </summary>
        public string Title
        {
            get => TitleWatchable.Value;
            set => TitleWatchable.Value = value;
        }

        public Watchable<long> WordCountWatchable = new Watchable<long>();
        /// <summary>
        /// The number of words the article content contains. 
        /// </summary>
        public long WordCount
        {
            get => WordCountWatchable.Value;
            set => WordCountWatchable.Value = value;
        }

        public Watchable<string> TypeWatchable = new Watchable<string>();
        /// <summary>
        /// The type of thing this article describes. E. g. "Character", "Nation", "Location", "Item", etc. 
        /// </summary>
        public string Type
        {
            get => TypeWatchable.Value;
            set => TypeWatchable.Value = value;
        }

        public WatchableCollection<LocalizedContent> ContentWatchable = new WatchableCollection<LocalizedContent>();
        /// <summary>
        /// The actual content of the article. 
        /// </summary>
        public ObservableList<LocalizedContent> Content
        {
            get => ContentWatchable.Collection;
            set => ContentWatchable.Collection = value;
        }

        public WatchableCollection<LocalizedContent> ProminentContentWatchable = new WatchableCollection<LocalizedContent>();
        /// <summary>
        /// List of prominent content, which should be displayed in its own, easily accessible block. 
        /// </summary>
        public ObservableList<LocalizedContent> ProminentContent
        {
            get => ProminentContentWatchable.Collection;
            set => ProminentContentWatchable.Collection = value;
        }

        public Article(Guid id)
        {
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