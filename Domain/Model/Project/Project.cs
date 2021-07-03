using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a project. 
    /// </summary>
    public class Project : IEquatable<Project>
    {
        public Watchable<ProjectId> IdWatchable { get; private set; } = new Watchable<ProjectId>();
        /// <summary>
        /// Name, path, id
        /// </summary>
        public ProjectId Id
        {
            get => IdWatchable.Value;
            private set => IdWatchable.Value = value;
        }

        public Watchable<string> LastWorkspaceWatchable { get; private set; } = new Watchable<string>();
        /// <summary>
        /// Name of the last opened workspace, e. g. "Canvas" or "Writing". 
        /// </summary>
        public string LastWorkspace
        {
            get => LastWorkspaceWatchable.Value;
            set => LastWorkspaceWatchable.Value = value;
        }

        public WatchableCollection<string> LastArticlesWatchable { get; private set; } = new WatchableCollection<string>();
        /// <summary>
        /// List of strings, representing project-relative file paths, of the articles still open when the editor/project was closed.
        /// </summary>
        public ObservableList<string> LastArticles
        {
            get => LastArticlesWatchable.Collection;
            set => LastArticlesWatchable.Collection = value;
        }

        public WatchableCollection<ArticleTemplate> TemplatesWatchable { get; private set; } = new WatchableCollection<ArticleTemplate>();
        /// <summary>
        /// List of article templates specific to this project (not added to the global list of templates). 
        /// </summary>
        public ObservableList<ArticleTemplate> Templates
        {
            get => TemplatesWatchable.Collection;
            set => TemplatesWatchable.Collection = value;
        }

        public WatchableCollection<ArticleGenerator> GeneratorsWatchable { get; private set; } = new WatchableCollection<ArticleGenerator>();
        /// <summary>
        /// List of article generators specific to this project (not added to the global list of generators). 
        /// </summary>
        public ObservableList<ArticleGenerator> Generators
        {
            get => GeneratorsWatchable.Collection;
            set => GeneratorsWatchable.Collection = value;
        }

        public Watchable<ProjectAssets> AssetsWatchable { get; private set; } = new Watchable<ProjectAssets>();
        /// <summary>
        /// Assets of this project. 
        /// </summary>
        public ProjectAssets Assets
        {
            get => AssetsWatchable.Value;
            set => AssetsWatchable.Value = value;
        }

        public Watchable<ProjectContent> ContentWatchable { get; private set; } = new Watchable<ProjectContent>();
        /// <summary>
        /// Content of this project (articles, canvas objects, etc.). 
        /// </summary>
        public ProjectContent Content
        {
            get => ContentWatchable.Value;
            set => ContentWatchable.Value = value;
        }

        public Project(ProjectId id)
        {
            Id = id;
        }

        public Project(Guid id, string name, string pathOnDisk, DateTime creationDate, DateTime lastEditDate)
        {
            Id = new ProjectId(id, name, pathOnDisk, creationDate, lastEditDate);
        }

        public Project(Guid id, string name, string pathOnDisk)
            : this(id, name, pathOnDisk, DateTime.Now, DateTime.Now)
        {
        }

        public bool Equals(Project other)
        {
            if (other == null)
                return false;
            else
                return other.Id == Id;
        }
    }
}