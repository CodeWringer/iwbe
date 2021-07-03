namespace StoreSystem
{
    public class WatchableCollection<T> : IWatchable, IWatchableCollection<T>
    {
        public event WatchableChanging Changing;
        public event WatchableChanged Changed;

        public event WatchableItemAddHandler<T> ItemAdding;
        public event WatchableItemRemoveHandler<T> ItemRemoving;
        public event WatchableItemReplaceHandler<T> ItemReplacing;
        public event WatchableItemMoveHandler<T> ItemMoving;
        public event WatchableSortHandler<T> ItemsSorting;

        public event WatchableItemAddHandler<T> ItemAdded;
        public event WatchableItemRemoveHandler<T> ItemRemoved;
        public event WatchableItemReplaceHandler<T> ItemReplaced;
        public event WatchableItemMoveHandler<T> ItemMoved;
        public event WatchableSortHandler<T> ItemsSorted;

        private ObservableList<T> _observable;
        public ObservableList<T> Collection
        {
            get { return _observable; }
            set
            {
                var oldValue = _observable;
                Changing?.Invoke(this, value, oldValue);
                _observable = value;
                Changed?.Invoke(this, Collection, oldValue);
            }
        }

        public WatchableCollection()
        {
            _observable = new ObservableList<T>();
            // Add
            _observable.ItemAdding += (ob, change) => { ItemAdding?.Invoke(this, change); };
            _observable.ItemAdded += (ob, change) => { ItemAdded?.Invoke(this, change); };
            // Remove
            _observable.ItemRemoving += (ob, change) => { ItemRemoving?.Invoke(this, change); };
            _observable.ItemRemoved += (ob, change) => { ItemRemoved?.Invoke(this, change); };
            // Replace
            _observable.ItemReplacing += (ob, change) => { ItemReplacing?.Invoke(this, change); };
            _observable.ItemReplaced += (ob, change) => { ItemReplaced?.Invoke(this, change); };
            // Move
            _observable.ItemMoving += (ob, change) => { ItemMoving?.Invoke(this, change); };
            _observable.ItemMoved += (ob, change) => { ItemMoved?.Invoke(this, change); };
            // Sort
            _observable.ItemsSorting += (ob, changes) => { ItemsSorting?.Invoke(this, changes); };
            _observable.ItemsSorted += (ob, changes) => { ItemsSorted?.Invoke(this, changes); };
        }
    }
}