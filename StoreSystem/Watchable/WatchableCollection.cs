namespace DataStore
{
    public class WatchableCollection<T> : IWatchable, IWatchableCollection<T>
    {
        public event WatchableChanging Changing;
        public event WatchableChanged Changed;

        public event WatchableItemAddHandler<T> ItemAdding;
        public event WatchableItemAddHandler<T> ItemAdded;

        public event WatchableItemRemoveHandler<T> ItemRemoving;
        public event WatchableItemRemoveHandler<T> ItemRemoved;

        public event WatchableItemMoveHandler<T> ItemMoving;
        public event WatchableItemMoveHandler<T> ItemMoved;

        public event WatchableItemReplaceHandler<T> ItemReplacing;
        public event WatchableItemReplaceHandler<T> ItemReplaced;

        public event WatchableSortHandler<T> ItemsSorting;
        public event WatchableSortHandler<T> ItemsSorted;

        public event WatchableClearHandler<T> ItemsClearing;
        public event WatchableClearHandler<T> ItemsCleared;

        public event WatchableItemsSetHandler<T> ItemsSetting;
        public event WatchableItemsSetHandler<T> ItemsSet;

        private ObservableList<T> _observable;
        public ObservableList<T> Collection
        {
            get { return _observable; }
            set
            {
                var oldValue = _observable;
                Changing?.Invoke(this, value, oldValue);
                _observable = value;
                Changed?.Invoke(this, value, oldValue);
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
            // Clear
            _observable.ItemsClearing += (ob, changes) => { ItemsClearing?.Invoke(this, changes); };
            _observable.ItemsCleared += (ob, changes) => { ItemsCleared?.Invoke(this, changes); };
            // SetItems
            _observable.ItemsSetting += (ob, changes) => { ItemsSetting?.Invoke(this, changes); };
            _observable.ItemsSet += (ob, changes) => { ItemsSet?.Invoke(this, changes); };
        }
    }
}