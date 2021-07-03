using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Template for a project. 
    /// </summary>
    public class ProjectTemplate
    {
        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public Guid Id { get; private set; }

        public Watchable<string> NameWatchable = new Watchable<string>();
        /// <summary>
        /// Display name. 
        /// </summary>
        public string Name
        {
            get => NameWatchable.Value;
            set => NameWatchable.Value = value;
        }

        public WatchableCollection<ArticleTemplate> TemplatesWatchable = new WatchableCollection<ArticleTemplate>();
        /// <summary>
        /// List of article templates specific to this project (not added to the global list of templates). 
        /// </summary>
        public ObservableList<ArticleTemplate> Templates
        {
            get => TemplatesWatchable.Collection;
            set => TemplatesWatchable.Collection = value;
        }

        public WatchableCollection<ArticleGenerator> GeneratorsWatchable = new WatchableCollection<ArticleGenerator>();
        /// <summary>
        /// List of article generators specific to this project (not added to the global list of generators). 
        /// </summary>
        public ObservableList<ArticleGenerator> Generators
        {
            get => GeneratorsWatchable.Collection;
            set => GeneratorsWatchable.Collection = value;
        }

        public ProjectTemplate(Guid id)
        {
            this.Id = id;
        }
    }
}
