using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStore
{
    public class ObservableList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, IWatchableCollection<T>
    {
        public event WatchableItemAddHandler<T> ItemAdding;
        public event WatchableItemAddHandler<T> ItemAdded;

        public event WatchableItemRemoveHandler<T> ItemRemoving;
        public event WatchableItemRemoveHandler<T> ItemRemoved;

        public event WatchableItemReplaceHandler<T> ItemReplacing;
        public event WatchableItemReplaceHandler<T> ItemReplaced;

        public event WatchableItemMoveHandler<T> ItemMoving;
        public event WatchableItemMoveHandler<T> ItemMoved;

        public event WatchableSortHandler<T> ItemsSorting;
        public event WatchableSortHandler<T> ItemsSorted;

        public event WatchableClearHandler<T> ItemsClearing;
        public event WatchableClearHandler<T> ItemsCleared;

        public event WatchableItemsSetHandler<T> ItemsSetting;
        public event WatchableItemsSetHandler<T> ItemsSet;

        private List<T> _wrappedList;

        public T this[int index] { get => _wrappedList[index]; set => _wrappedList[index] = value; }

        public int Count => _wrappedList.Count;

        public bool IsReadOnly => false;

        public ObservableList()
        {
            _wrappedList = new List<T>();
        }

        public ObservableList(IEnumerable<T> collection)
        {
            _wrappedList = new List<T>(collection);
        }

        public void Add(T item)
        {
            int index = _wrappedList.Count;
            var change = new ItemAddRemoveChange<T>(index, item);
            ItemAdding?.Invoke(this, change);
            _wrappedList.Add(item);
            ItemAdded?.Invoke(this, change);
        }

        public void Insert(int index, T item)
        {
            var change = new ItemAddRemoveChange<T>(index, item);
            ItemAdding?.Invoke(this, change);
            _wrappedList.Insert(index, item);
            ItemAdded?.Invoke(this, change);
        }

        public void Clear()
        {
            var changes = new List<ItemAddRemoveChange<T>>();

            for (int index = 0; index < _wrappedList.Count; index++)
            {
                var item = _wrappedList[index];
                changes.Add(new ItemAddRemoveChange<T>(index, item));
            }

            ItemsClearing?.Invoke(this, changes);
            _wrappedList.Clear();
            ItemsCleared?.Invoke(this, changes);
        }

        public bool Remove(T item)
        {
            int index = _wrappedList.IndexOf(item);
            var change = new ItemAddRemoveChange<T>(index, item);
            ItemRemoving?.Invoke(this, change);
            bool success = _wrappedList.Remove(item);
            ItemRemoved?.Invoke(this, change);

            return success;
        }

        public void RemoveAt(int index)
        {
            var item = _wrappedList[index];
            var change = new ItemAddRemoveChange<T>(index, item);
            ItemRemoving?.Invoke(this, change);
            _wrappedList.RemoveAt(index);
            ItemRemoved?.Invoke(this, change);
        }

        public void Replace(T toReplace, T replaceWith)
        {
            int index = _wrappedList.IndexOf(toReplace);
            var change = new ItemReplaceChange<T>(index, toReplace, replaceWith);
            ItemReplacing?.Invoke(this, change);
            _wrappedList.RemoveAt(index);
            _wrappedList.Insert(index, replaceWith);
            ItemReplaced?.Invoke(this, change);
        }

        public void ReplaceAt(int index, T replaceWith)
        {
            var toReplace = _wrappedList[index];
            var change = new ItemReplaceChange<T>(index, toReplace, replaceWith);
            ItemReplacing?.Invoke(this, change);
            _wrappedList.RemoveAt(index);
            _wrappedList.Insert(index, replaceWith);
            ItemReplaced?.Invoke(this, change);
        }

        public void Move(int indexFrom, int indexTo)
        {
            var item = _wrappedList[indexFrom];
            var change = new ItemMoveChange<T>(indexFrom, indexTo, item);
            ItemMoving?.Invoke(this, change);
            _wrappedList.RemoveAt(indexFrom);
            _wrappedList.Insert(indexTo, item);
            ItemMoved?.Invoke(this, change);
        }

        private IEnumerable<ItemMoveChange<T>> GetItemMoveChanges(IEnumerable<T> enumerable)
        {
            var changes = new List<ItemMoveChange<T>>();
            int newIndex = 0;
            foreach (var item in enumerable)
            {
                int oldIndex = _wrappedList.IndexOf(item);
                changes.Add(new ItemMoveChange<T>(oldIndex, newIndex, item));

                newIndex++;
            }
            return changes;
        }

        public void Sort()
        {
            var sorted = new List<T>(_wrappedList);
            sorted.Sort();

            var changes = GetItemMoveChanges(sorted);

            ItemsSorting?.Invoke(this, changes);
            _wrappedList = sorted;
            ItemsSorted?.Invoke(this, changes);
        }

        public void Sort(Comparison<T> comparison)
        {
            var sorted = new List<T>(_wrappedList);
            sorted.Sort(comparison);

            var changes = GetItemMoveChanges(sorted);

            ItemsSorting?.Invoke(this, changes);
            _wrappedList = sorted;
            ItemsSorted?.Invoke(this, changes);
        }

        public void Sort(IComparer<T> comparer)
        {
            var sorted = new List<T>(_wrappedList);
            sorted.Sort(comparer);

            var changes = GetItemMoveChanges(sorted);

            ItemsSorting?.Invoke(this, changes);
            _wrappedList = sorted;
            ItemsSorted?.Invoke(this, changes);
        }

        public void Sort(int index, int count, IComparer<T> comparer = null)
        {
            var sorted = new List<T>(_wrappedList);
            sorted.Sort(index, count, comparer);

            var changes = GetItemMoveChanges(sorted);

            ItemsSorting?.Invoke(this, changes);
            _wrappedList = sorted;
            ItemsSorted?.Invoke(this, changes);
        }

        public void SetItems(IEnumerable<T> items)
        {
            ItemsSetting?.Invoke(this, new ItemsSetChange<T>(items, _wrappedList));
            _wrappedList.Clear();
            _wrappedList.AddRange(items);
            ItemsSet?.Invoke(this, new ItemsSetChange<T>(items, _wrappedList));
        }

        public bool Contains(T item)
        {
            return _wrappedList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _wrappedList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _wrappedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _wrappedList.IndexOf(item);
        }
    }
}
