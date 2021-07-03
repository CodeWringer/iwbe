using Iwbe.Domain.Model;
using StoreSystem;

namespace Iwbe.Domain.StoreSystem
{
    public class ProjectState
    {
        public Watchable<Project> ActiveProjectWatchable = new Watchable<Project>();
        /// <summary>
        /// The currently loaded and active project. 
        /// </summary>
        public Project ActiveProject
        {
            get => ActiveProjectWatchable.Value;
            set => ActiveProjectWatchable.Value = value;
        }

        public WatchableCollection<ProjectId> PinnedProjectsWatchable { get; private set; } = new WatchableCollection<ProjectId>();
        /// <summary>
        /// The currently pinned projects. 
        /// </summary>
        public ObservableList<ProjectId> PinnedProjects
        {
            get => PinnedProjectsWatchable.Collection;
            set => PinnedProjectsWatchable.Collection = value;
        }

        public WatchableCollection<ProjectId> RecentProjectsWatchable { get; private set; } = new WatchableCollection<ProjectId>();
        /// <summary>
        /// The recently opened projects. 
        /// </summary>
        public ObservableList<ProjectId> RecentProjects
        {
            get => RecentProjectsWatchable.Collection;
            set => RecentProjectsWatchable.Collection = value;
        }

        public WatchableCollection<ProjectTemplate> TemplatesWatchable { get; private set; } = new WatchableCollection<ProjectTemplate>();
        /// <summary>
        /// Currently loaded project templates. 
        /// </summary>
        public ObservableList<ProjectTemplate> Templates
        {
            get => TemplatesWatchable.Collection;
            set => TemplatesWatchable.Collection = value;
        }

        public Watchable<ProjectSort> PinnedProjectsSortWatchable = new Watchable<ProjectSort>();
        /// <summary>
        /// Sort direction of pinned projects. 
        /// </summary>
        public ProjectSort PinnedProjectsSort
        {
            get => PinnedProjectsSortWatchable.Value;
            set => PinnedProjectsSortWatchable.Value = value;
        }

        public Watchable<ProjectSort> RecentProjectsSortWatchable = new Watchable<ProjectSort>();
        /// <summary>
        /// Sort direction of recent projects. 
        /// </summary>
        public ProjectSort RecentProjectsSort
        {
            get => RecentProjectsSortWatchable.Value;
            set => RecentProjectsSortWatchable.Value = value;
        }

        public ProjectState()
        {
            var sort = new ProjectSort(SortDirections.Descending, ProjectSortProperties.LastEditDate);
            this.PinnedProjectsSort = sort;
            this.RecentProjectsSort = sort;
        }
    }
}