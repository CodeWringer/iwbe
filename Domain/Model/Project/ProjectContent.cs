using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents the content (articles, canvas objects, etc.) of a project. 
    /// </summary>
    public class ProjectContent
    {
        public WatchableCollection<string> WritingWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of project-relative file paths of article definitions. 
        /// </summary>
        public ObservableList<string> Writing
        {
            get => WritingWatchable.Collection;
            set => WritingWatchable.Collection = value;
        }

        public WatchableCollection<string> CanvasWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of project-relative file paths of canvas objects. 
        /// </summary>
        public ObservableList<string> Canvas
        {
            get => CanvasWatchable.Collection;
            set => CanvasWatchable.Collection = value;
        }

        public WatchableCollection<string> HierarchiesWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of project-relative file paths of hierarchy definitions. 
        /// </summary>
        public ObservableList<string> Hierarchies
        {
            get => HierarchiesWatchable.Collection;
            set => HierarchiesWatchable.Collection = value;
        }

        public WatchableCollection<string> TimelineWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of project-relative file paths of timeline definitions. 
        /// </summary>
        public ObservableList<string> Timeline
        {
            get => TimelineWatchable.Collection;
            set => TimelineWatchable.Collection = value;
        }
    }
}