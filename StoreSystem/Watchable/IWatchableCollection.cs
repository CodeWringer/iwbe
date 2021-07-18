using System.Collections.Generic;

namespace DataStore
{
    // Non-generic events. 
    public delegate void WatchableItemAddHandler(IWatchableCollection watchable, ItemAddRemoveChange change);
    public delegate void WatchableItemRemoveHandler(IWatchableCollection watchable, ItemAddRemoveChange change);
    public delegate void WatchableItemReplaceHandler(IWatchableCollection watchable, ItemReplaceChange change);
    public delegate void WatchableItemMoveHandler(IWatchableCollection watchable, ItemMoveChange change);
    public delegate void WatchableSortHandler(IWatchableCollection watchable, IEnumerable<ItemMoveChange> changes);
    public delegate void WatchableClearHandler(IWatchableCollection watchable, IEnumerable<ItemAddRemoveChange> changes);
    public delegate void WatchableItemsSetHandler(IWatchableCollection watchable, ItemsSetChange change);

    // Generic events. 
    public delegate void WatchableItemAddHandler<T>(IWatchableCollection<T> watchable, ItemAddRemoveChange<T> change);
    public delegate void WatchableItemRemoveHandler<T>(IWatchableCollection<T> watchable, ItemAddRemoveChange<T> change);
    public delegate void WatchableItemReplaceHandler<T>(IWatchableCollection<T> watchable, ItemReplaceChange<T> change);
    public delegate void WatchableItemMoveHandler<T>(IWatchableCollection<T> watchable, ItemMoveChange<T> change);
    public delegate void WatchableSortHandler<T>(IWatchableCollection<T> watchable, IEnumerable<ItemMoveChange<T>> changes);
    public delegate void WatchableClearHandler<T>(IWatchableCollection<T> watchable, IEnumerable<ItemAddRemoveChange<T>> changes);
    public delegate void WatchableItemsSetHandler<T>(IWatchableCollection<T> watchable, ItemsSetChange<T> change);

    public interface IWatchableCollection
    {
        event WatchableItemAddHandler ItemAdding;
        event WatchableItemAddHandler ItemAdded;

        event WatchableItemRemoveHandler ItemRemoving;
        event WatchableItemRemoveHandler ItemRemoved;

        event WatchableItemReplaceHandler ItemReplacing;
        event WatchableItemReplaceHandler ItemReplaced;

        event WatchableItemMoveHandler ItemMoving;
        event WatchableItemMoveHandler ItemMoved;

        event WatchableSortHandler ItemsSorting;
        event WatchableSortHandler ItemsSorted;

        event WatchableClearHandler ItemsClearing;
        event WatchableClearHandler ItemsCleared;

        event WatchableItemsSetHandler ItemsSetting;
        event WatchableItemsSetHandler ItemsSet;
    }

    public interface IWatchableCollection<T>
    {
        event WatchableItemAddHandler<T> ItemAdding;
        event WatchableItemAddHandler<T> ItemAdded;

        event WatchableItemRemoveHandler<T> ItemRemoving;
        event WatchableItemRemoveHandler<T> ItemRemoved;

        event WatchableItemReplaceHandler<T> ItemReplacing;
        event WatchableItemReplaceHandler<T> ItemReplaced;

        event WatchableItemMoveHandler<T> ItemMoving;
        event WatchableItemMoveHandler<T> ItemMoved;

        event WatchableClearHandler<T> ItemsClearing;
        event WatchableClearHandler<T> ItemsCleared;

        event WatchableItemsSetHandler<T> ItemsSetting;
        event WatchableItemsSetHandler<T> ItemsSet;
    }

    public struct ItemMoveChange
    {
        public int OldIndex { get; private set; }
        public int NewIndex { get; private set; }
        public object Item { get; private set; }

        public ItemMoveChange(int oldIndex, int newIndex, object item)
        {
            OldIndex = oldIndex;
            NewIndex = newIndex;
            Item = item;
        }
    }

    public struct ItemMoveChange<T>
    {
        public int OldIndex { get; private set; }
        public int NewIndex { get; private set; }
        public T Item { get; private set; }

        public ItemMoveChange(int oldIndex, int newIndex, T item)
        {
            OldIndex = oldIndex;
            NewIndex = newIndex;
            Item = item;
        }
    }

    public struct ItemAddRemoveChange
    {
        public int Index { get; private set; }
        public object Item { get; private set; }

        public ItemAddRemoveChange(int index, object item)
        {
            Index = index;
            Item = item;
        }
    }

    public struct ItemsSetChange
    {
        public IEnumerable<object> NewItems { get; private set; }
        public IEnumerable<object> OldItems { get; private set; }

        public ItemsSetChange(IEnumerable<object> newItems, IEnumerable<object> oldItems)
        {
            NewItems = newItems;
            OldItems = oldItems;
        }
    }

    public struct ItemAddRemoveChange<T>
    {
        public int Index { get; private set; }
        public T Item { get; private set; }

        public ItemAddRemoveChange(int index, T item)
        {
            Index = index;
            Item = item;
        }
    }

    public struct ItemReplaceChange
    {
        public int Index { get; private set; }
        public object ToReplace { get; private set; }
        public object ReplaceWith { get; private set; }

        public ItemReplaceChange(int index, object toReplace, object replaceWith)
        {
            Index = index;
            ToReplace = toReplace;
            ReplaceWith = replaceWith;
        }
    }

    public struct ItemReplaceChange<T>
    {
        public int Index { get; private set; }
        public T ToReplace { get; private set; }
        public T ReplaceWith { get; private set; }

        public ItemReplaceChange(int index, T toReplace, T replaceWith)
        {
            Index = index;
            ToReplace = toReplace;
            ReplaceWith = replaceWith;
        }
    }

    public struct ItemsSetChange<T>
    {
        public IEnumerable<T> NewItems { get; private set; }
        public IEnumerable<T> OldItems { get; private set; }

        public ItemsSetChange(IEnumerable<T> newItems, IEnumerable<T> oldItems)
        {
            NewItems = newItems;
            OldItems = oldItems;
        }
    }
}