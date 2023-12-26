using iwbe.business.dataaccess.dto;
using iwbe.common.observables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a project. 
    /// </summary>
    public class Project : IEquatable<Project>, IObservableData, ISerializable<Project, ProjectDto>
    {
        internal static Project FromDto(ProjectDto dto)
        {
            var id = ProjectId.FromDto(dto.id);
            return new Project(id);
        }

        public event IObservableData.ChangedHandler Changed;

        /// <summary>
        /// The project's metadata, which uniquely identifies it. 
        /// </summary>
        public ProjectId ID { get; private set; }

        /// <summary>
        /// Name of the last opened workspace, e. g. "Canvas" or "Writing". 
        /// </summary>
        public ObservableData<string> LastWorkspace;

        /// <summary>
        /// List of strings, representing project-relative file paths, of the articles still open when the editor/project was closed.
        /// </summary>
        public ObservableDataCollection<string> LastArticles;

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
        public ObservableData<ProjectAssets> Assets;

        /// <summary>
        /// Content of this project (articles, canvas objects, etc.). 
        /// </summary>
        public ObservableData<ProjectContent> Content;

        private Project()
        {
            LastWorkspace = new ObservableData<string>();
            LastWorkspace.Changed += Changed;

            LastArticles = new ObservableDataCollection<string>();
            LastArticles.Changed += Changed;

            Assets = new ObservableData<ProjectAssets>();
            Assets.Changed += Changed;

            Content = new ObservableData<ProjectContent>();
            Content.Changed += Changed;
        }

        public Project(ProjectId id)
            : this()
        {
            ID = id;
        }

        public Project(string name, Guid id, string pathOnDisk, DateTime creationDate, DateTime lastEditDate)
            : this()
        {
            ID = new ProjectId(name, pathOnDisk, id, creationDate, lastEditDate);
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
            return this.ID.GetHashCode();
        }

        public ProjectDto ToDto()
        {
            var lastArticles = new List<string>();
            foreach (var lastArticle in LastArticles)
            {
                lastArticles.Add(lastArticle.Value);
            }

            return new ProjectDto()
            {
                id = ID.ToDto(),
                lastWorkspace = LastWorkspace.Value,
                lastArticles = lastArticles.ToArray(),
            };
        }
    }
}