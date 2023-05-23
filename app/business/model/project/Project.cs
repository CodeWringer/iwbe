using iwbe.business.util.watchable;
using System;
using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a project. 
    /// </summary>
    public class Project : IEquatable<Project>, IWatchable
    {
        public event WatchableChangeHandler Changed;

        /// <summary>
        /// The project's metadata, which uniquely identifies it. 
        /// </summary>
        public ProjectId ID { get; private set; }

        /// <summary>
        /// Name of the last opened workspace, e. g. "Canvas" or "Writing". 
        /// </summary>
        public Watchable<string> LastWorkspace { get; private set; } = new();

        /// <summary>
        /// List of strings, representing project-relative file paths, of the articles still open when the editor/project was closed.
        /// </summary>
        public List<string> LastArticles;

        ///// <summary>
        ///// List of article templates specific to this project (not added to the global list of templates). 
        ///// </summary>
        //public List<ArticleTemplate> Templates;

        ///// <summary>
        ///// List of article generators specific to this project (not added to the global list of generators). 
        ///// </summary>
        //public List<ArticleGenerator> Generators;

        /// <summary>
        /// Assets of this project. 
        /// </summary>
        public ProjectAssets Assets;

        /// <summary>
        /// Content of this project (articles, canvas objects, etc.). 
        /// </summary>
        public ProjectContent Content;

        public Project(ProjectId id)
        {
            ID = id;
        }

        public Project(string name, Guid id, string pathOnDisk, DateTime creationDate, DateTime lastEditDate)
        {
            ID = new ProjectId()
            {
                Name = name,
                ID = id,
                PathOnDisk = pathOnDisk,
                CreationDate = creationDate,
                LastEditDate = lastEditDate
            };
        }

        public Project(string name, Guid id, string pathOnDisk)
            : this(name, id, pathOnDisk, DateTime.Now, DateTime.Now)
        {
        }

        public bool Equals(Project other)
        {
            return other.ID == ID;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Project);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}