using StoreSystem;
using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents article content, specific to a locale. 
    /// </summary>
    public class LocalizedContent
    {
        public Watchable<string> LanguageWatchable = new Watchable<string>();
        /// <summary>
        /// The associated language. E. g. "en", "en-us", "de", "de-de", etc.
        /// </summary>
        public string Language
        {
            get => LanguageWatchable.Value;
            set => LanguageWatchable.Value = value;
        }

        public Watchable<string> ContentWatchable = new Watchable<string>();
        /// <summary>
        /// Represents article content. 
        /// TODO: Determine if a more memory-friendly/performant way of storing this than a single, big string is possible. 
        /// </summary>
        public string Content
        {
            get => ContentWatchable.Value;
            set => ContentWatchable.Value = value;
        }

        public WatchableCollection<InlineImage> ImagesWatchable = new WatchableCollection<InlineImage>();
        /// <summary>
        /// List of inline images. 
        /// </summary>
        public ObservableList<InlineImage> Images
        {
            get => ImagesWatchable.Collection;
            set => ImagesWatchable.Collection = value;
        }

        public WatchableCollection<InlineFont> FontsWatchable = new WatchableCollection<InlineFont>();
        /// <summary>
        /// List of inline fonts. 
        /// </summary>
        public ObservableList<InlineFont> Fonts
        {
            get => FontsWatchable.Collection;
            set => FontsWatchable.Collection = value;
        }

        public WatchableCollection<InlineAtReference> AtReferencesWatchable = new WatchableCollection<InlineAtReference>();
        /// <summary>
        /// List of @-References. 
        /// </summary>
        public ObservableList<InlineAtReference> AtReferences
        {
            get => AtReferencesWatchable.Collection;
            set => AtReferencesWatchable.Collection = value;
        }
    }
}