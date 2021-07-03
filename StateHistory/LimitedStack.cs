using System;
using System.Collections;
using System.Collections.Generic;

namespace StateHistory
{
    /// <summary>
    /// Represents a variable, but limited last-in-first-out (LIFO) collection of instances of
    /// the same specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack. </typeparam>
    public class LimitedStack<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        protected int _maxEntryCount;
        /// <summary>
        /// The maximum number of entries this tack may hold. Once reached, will start discarding elements at the 
        /// beginning of the stack (= the oldest entries are discarded first). 
        /// 
        /// If changed to a lower number than the current item count, will start truncating from the beginning 
        /// of the stack (= the oldest entries are discarded first), to meet the new limit. 
        /// </summary>
        public int MaxEntryCount
        {
            get { return this._maxEntryCount; }
            set 
            { 
                this._maxEntryCount = value; 

                if (this._items.Count >= this._maxEntryCount)
                {
                    var newList = new List<T>(this._maxEntryCount);
                    int startAt = this._items.Count - this._maxEntryCount;
                    for (int i = startAt; i < _items.Count; i++)
                    {
                        newList.Add(this._items[i]);
                    }

                    this._items = newList;
                }
            }
        }

        /// <summary>
        /// The items contained in this LimitedStack.
        /// </summary>
        protected List<T> _items;

        /// <summary>
        /// Returns the number of elements contained in the LimitedStack. 
        /// </summary>
        public int Count
        { 
            get { return this._items.Count; } 
            protected set { /* Do nothing. */ } 
        }

        /// <summary>
        /// Initializes a new instance of LimitedStack, with the capacity and items based on the given IEnumerable. 
        /// </summary>
        /// <param name="collection">The items to contain initially. </param>
        public LimitedStack(IEnumerable<T> collection, int maxEntries = 255)
        {
            this._items = new List<T>(collection);
            this.MaxEntryCount = maxEntries;
        }

        /// <summary>
        /// Initializes a new empty instance of LimitedStack. 
        /// </summary>
        public LimitedStack(int maxEntries = 255)
            : this(new List<T>(), maxEntries)
        {
        }

        /// <summary>
        /// Initializes a new empty instance of LimitedStack with the given starting capacity. 
        /// </summary>
        /// <param name="capacity">The initial capacity. </param>
        public LimitedStack(int capacity, int maxEntries = 255)
            : this(new List<T>(capacity), maxEntries)
        {
        }

        /// <summary>
        /// Removes all objects from the LimitedStack. 
        /// </summary>
        public void Clear()
        {
            this._items.Clear();
        }

        /// <summary>
        /// Returns true, if the given item is contained in this LimitedStack. 
        /// </summary>
        /// <param name="item">The item to test if it is contained. </param>
        /// <returns>True, if the item is contained. </returns>
        public bool Contains(T item)
        {
            return this._items.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this._items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (this._items.Count == 0)
                throw new IndexOutOfRangeException("The stack contains no items!");

            return this._items[this._items.Count - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (this._items.Count == 0)
                throw new IndexOutOfRangeException("The stack contains no items!");

            var result = this._items[this._items.Count - 1];
            this._items.RemoveAt(this._items.Count - 1);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (this._items.Count + 1 > this.MaxEntryCount)
                this._items.RemoveAt(0);

            this._items.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return this._items.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryPeek(out T result)
        {
            result = default;

            if (this._items.Count == 0)
                return false;

            result = this._items[this._items.Count - 1];

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryPop(out T result)
        {
            result = default;

            if (this._items.Count == 0)
                return false;

            result = this._items[this._items.Count - 1];
            this._items.RemoveAt(this._items.Count - 1);

            return true;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }
    }
}