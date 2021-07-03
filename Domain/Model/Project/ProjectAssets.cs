using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents the assets (images, fonts, etc.) of a project. 
    /// </summary>
    public class ProjectAssets
    {
        public WatchableCollection<string> ImagesWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of full file paths of image files. 
        /// </summary>
        public ObservableList<string> Images
        {
            get => ImagesWatchable.Collection;
            set => ImagesWatchable.Collection = value;
        }

        public WatchableCollection<string> FontsWatchable = new WatchableCollection<string>();
        /// <summary>
        /// List of full file paths of font files. 
        /// </summary>
        public ObservableList<string> Fonts
        {
            get => FontsWatchable.Collection;
            set => FontsWatchable.Collection = value;
        }
    }
}