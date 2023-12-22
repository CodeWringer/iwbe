using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iwbe.common.observables
{
    /// <summary>
    /// Represents the possible changes of a collection. 
    /// </summary>
    public enum CollectionChangeTypes
    {
        /// <summary>
        /// One or more elements were added. 
        /// </summary>
        ADD,
        /// <summary>
        /// One or more elements were removed. 
        /// </summary>
        REMOVE,
        /// <summary>
        /// One or more elements were moved / re-ordered. 
        /// </summary>
        MOVE,
        /// <summary>
        /// One or more elements were replaced. 
        /// </summary>
        REPLACE,
        /// <summary>
        /// One or more elements' internal state changed. 
        /// </summary>
        ELEMENT,
    }

    /// <summary>
    /// Abstract base event args class for when any data of the collection changes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OnChangedEventArgs<T>
    {
        public CollectionChangeTypes ChangeType { get; private set; }

        public OnChangedEventArgs(CollectionChangeTypes changeType)
        {
            ChangeType = changeType;
        }
    }

    public class OnChangedElementEventArgs<T> : OnChangedEventArgs<T>
    {
        public ObservableField<T> Element { get; private set; }
        
        public T OldValue { get; private set; }

        public T NewValue { get; private set; }

        public OnChangedElementEventArgs(ObservableField<T> element, T oldValue, T newValue)
            : base(CollectionChangeTypes.ELEMENT)
        {
            Element = element;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class OnChangedListEventArgs<T> : OnChangedEventArgs<T>
    {
        public IEnumerable<ObservableField<T>> OldList { get; private set; }

        public IEnumerable<ObservableField<T>> NewList { get; private set; }

        public OnChangedListEventArgs(CollectionChangeTypes changeType, IEnumerable<ObservableField<T>> oldList, IEnumerable<ObservableField<T>> newList)
            : base(changeType)
        {
            OldList = oldList;
            NewList = newList;
        }
    }

    /// <summary>
    /// Represents a collection/list whose data set changes can be observed/listened for. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableDataCollection<T> : IObservableData, ICollection<ObservableField<T>> where T : class
    {
        public delegate void onChangedHandler(IObservableData sender, OnChangedEventArgs<T> e);

        public event IObservableData.onChangedHandler OnChanged;

        public event onChangedHandler OnListChanged;

        private List<ObservableField<T>> _wrapped;

        public int Count => _wrapped.Count;

        public bool IsReadOnly => false;

        public ObservableField<T> this[int index] => _wrapped[index];

        public ObservableDataCollection()
        {
            _wrapped = new List<ObservableField<T>>();
        }

        public ObservableDataCollection(IEnumerable<ObservableField<T>> elements)
        {
            _wrapped = new List<ObservableField<T>>(elements);
            foreach (var element in elements)
            {
                element.OnValueChanged += Element_OnValueChanged;
            }
        }

        /// <summary>
        /// Adds the given element at the end of the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(ObservableField<T> item)
        {
            _wrapped.Add(item);
            item.OnValueChanged += Element_OnValueChanged;
        }

        /// <summary>
        /// Adds the given element at the given index. 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void AddAt(ObservableField<T> item, int index)
        {
            _wrapped.Insert(index, item);
            item.OnValueChanged += Element_OnValueChanged;
        }

        /// <summary>
        /// Adds the given elements to the end of the collection.
        /// </summary>
        /// <param name="elements"></param>
        public void AddRange(IEnumerable<ObservableField<T>> elements)
        {
            _wrapped.AddRange(elements);
            foreach(var element in elements)
            {
                element.OnValueChanged += Element_OnValueChanged;
            }
        }

        /// <summary>
        /// Removes all elements. 
        /// </summary>
        public void Clear()
        {
            foreach (var item in _wrapped)
            {
                item.OnValueChanged -= Element_OnValueChanged;
            }
            _wrapped.Clear();
        }

        /// <summary>
        /// Returns true, if the given element is contained.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ObservableField<T> item)
        {
            return _wrapped.Contains(item);
        }

        public void CopyTo(ObservableField<T>[] array, int arrayIndex)
        {
            _wrapped.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the given element. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(ObservableField<T> item)
        {
            item.OnValueChanged -= Element_OnValueChanged;
            return _wrapped.Remove(item);
        }

        /// <summary>
        /// Removes and returns the element at the given index. 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveAt(int index)
        {
            var element = _wrapped[index];
            return Remove(element);
        }

        /// <summary>
        /// Attempts to replace the given element with the given element. 
        /// </summary>
        /// <param name="toReplace"></param>
        /// <param name="replaceWith"></param>
        public void Replace(T toReplace, T replaceWith)
        {

        }

        public IEnumerator<ObservableField<T>> GetEnumerator()
        {
            return _wrapped.GetEnumerator();
        }

        /// <summary>
        /// Returns the index of the given element, if possible. If the element could not be found, returns `-1`. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ObservableField<T> item)
        {
            return _wrapped.IndexOf(item);
        }

        public IEnumerable<ObservableField<T>> GetAll()
        {
            return _wrapped.ToArray();
        }

        /// <summary>
        /// Moves an element at the given index to the given index. 
        /// </summary>
        /// <param name="fromIndex">Index of the element to move. </param>
        /// <param name="toIndex">Index to move the element to.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown, if the given `fromIndex` is out of bounds. </exception>
        public void Move(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || fromIndex > _wrapped.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var oldList = _wrapped.ToArray();

            // Ensure the new index remains bounded. 
            var newIndex = Math.Max(Math.Min(_wrapped.Count - 1, toIndex), 0);

            // "Move" the object by first removing and then re-inserting it at the desired index.
            var element = _wrapped[fromIndex];
            _wrapped.RemoveAt(fromIndex);
            _wrapped.Insert(newIndex, element);

            this.OnListChanged?.Invoke(this, new OnChangedListEventArgs<T>(CollectionChangeTypes.MOVE, oldList, _wrapped.ToArray()));
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Element_OnValueChanged(IObservableData sender, T oldValue, T newValue)
        {
            var observableField = sender as ObservableField<T>;
            this.OnListChanged?.Invoke(this, new OnChangedElementEventArgs<T>(observableField, oldValue, newValue));
        }
    }
}
