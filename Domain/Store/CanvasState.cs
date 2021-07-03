using Iwbe.Domain.Model;
using StoreSystem;

namespace Iwbe.Domain.StoreSystem
{
    public class CanvasState
    {
        public WatchableCollection<CanvasDrawable> DrawablesWatchable { get; private set; } = new WatchableCollection<CanvasDrawable>();
        public ObservableList<CanvasDrawable> Drawables
        {
            get => DrawablesWatchable.Collection;
            set => DrawablesWatchable.Collection = value;
        }

        public ObservableHierarchyDataLinker<CanvasDrawable> HierarchyLinks = new ObservableHierarchyDataLinker<CanvasDrawable>();

        public CanvasState()
        {
        }
    }
}