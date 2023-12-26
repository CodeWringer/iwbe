using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

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

    public class ChangedEventArgs<T>
    {
        public CollectionChangeTypes ChangeType { get; private set; }

        public IEnumerable<ElementChangedEventArgs<T>> Elements { get; private set; }

        public ChangedEventArgs(CollectionChangeTypes changeType, IEnumerable<ElementChangedEventArgs<T>> elements)
        {
            ChangeType = changeType;
            Elements = elements;
        }
    }

    public class ElementChangedEventArgs<T>
    {
        public ObservableData<T> Element { get; private set; }
        
        public int OldIndex { get; private set; }

        public int NewIndex { get; private set; }

        /// <summary>
        /// The internal data state of the element that was changed. 
        /// Can be null in case an element's internal state was NOT changed. 
        /// </summary>
        public ValueChangedEventArgs<T> ElementChangeArgs { get; private set; }

        public ElementChangedEventArgs(ObservableData<T> element, int oldIndex, int newIndex, ValueChangedEventArgs<T> elementChangeArgs = null)
        {
            Element = element;
            OldIndex = oldIndex;
            NewIndex = newIndex;
            ElementChangeArgs = elementChangeArgs;
        }
    }

    /// <summary>
    /// Represents a collection/list whose data set changes can be observed/listened for. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableDataCollection<T> : IObservableData, ICollection<ObservableData<T>> where T : class
    {
        public delegate void ChangedHandler(IObservableData sender, ChangedEventArgs<T> e);

        public event IObservableData.ChangedHandler Changed;

        public event ChangedHandler ListChanged;

        private List<ObservableData<T>> _wrapped;

        public int Count => _wrapped.Count;

        public bool IsReadOnly => false;

        public ObservableData<T> this[int index] => _wrapped[index];

        public ObservableDataCollection()
        {
            _wrapped = new List<ObservableData<T>>();
        }

        public ObservableDataCollection(IEnumerable<ObservableData<T>> elements)
        {
            _wrapped = new List<ObservableData<T>>(elements);
            foreach (var element in elements)
            {
                element.ValueChanged += Element_OnValueChanged;
            }
        }

        /// <summary>
        /// Adds the given element at the end of the collection. 
        /// 
        /// Silently ignores attempts to add elements that are already contained. 
        /// </summary>
        /// <param name="element"></param>
        public void Add(ObservableData<T> element)
        {
            if (Contains(element)) return;

            _wrapped.Add(element);
            element.ValueChanged += Element_OnValueChanged;

            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.ADD, new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(element, -1, _wrapped.Count)
            }));
            Changed?.Invoke(this);
        }

        /// <summary>
        /// Adds the given element at the given index. 
        /// 
        /// Silently ignores attempts to add elements that are already contained. 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public void AddAt(ObservableData<T> element, int index)
        {
            if (Contains(element)) return;

            _wrapped.Insert(index, element);
            element.ValueChanged += Element_OnValueChanged;

            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.ADD, new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(element, -1, index)
            }));
            Changed?.Invoke(this);
        }

        /// <summary>
        /// Adds the given elements to the end of the collection.
        /// 
        /// Silently ignores attempts to add elements that are already contained. 
        /// </summary>
        /// <param name="elements"></param>
        public void AddRange(IEnumerable<ObservableData<T>> elements)
        {
            var args = new List<ElementChangedEventArgs<T>>();

            foreach(var element in elements)
            {
                if (Contains(element)) continue;

                _wrapped.Add(element);
                element.ValueChanged += Element_OnValueChanged;
                int index = IndexOf(element);
                args.Add(new ElementChangedEventArgs<T>(element, -1, index));
            }

            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.ADD, args));
            Changed?.Invoke(this);
        }

        /// <summary>
        /// Removes all elements. 
        /// </summary>
        public void Clear()
        {
            var args = new List<ElementChangedEventArgs<T>>();
            foreach (var element in _wrapped)
            {
                element.ValueChanged -= Element_OnValueChanged;
                int index = IndexOf(element);
                args.Add(new ElementChangedEventArgs<T>(element, index, -1));
            }
            _wrapped.Clear();

            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.REMOVE, args));
            Changed?.Invoke(this);
        }

        /// <summary>
        /// Returns true, if the given element is contained.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ObservableData<T> item)
        {
            return _wrapped.Contains(item);
        }

        public void CopyTo(ObservableData<T>[] array, int arrayIndex)
        {
            _wrapped.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the given element. 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(ObservableData<T> element)
        {
            if (Contains(element) == false) return false;

            element.ValueChanged -= Element_OnValueChanged;
            bool result = _wrapped.Remove(element);

            var args = new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(element, IndexOf(element), -1),
            };
            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.REMOVE, args));
            Changed?.Invoke(this);

            return result;
        }

        /// <summary>
        /// Removes and returns the element at the given index. 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveAt(int index)
        {
            var element = _wrapped[index];
            if (element == null) return false;

            element.ValueChanged -= Element_OnValueChanged;
            bool result = Remove(element);

            var args = new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(element, index, -1),
            };
            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.REMOVE, args));
            Changed?.Invoke(this);

            return result;
        }

        /// <summary>
        /// Attempts to replace the given element with the given element. 
        /// </summary>
        /// <param name="toReplace"></param>
        /// <param name="replaceWith"></param>
        /// <exception cref="InvalidOperationException">Thrown, if both elements are already contained, 
        /// or if <paramref name="toReplace"/> is not contained 
        /// or if <paramref name="replaceWith"/> is already contained
        /// </exception>
        public void Replace(ObservableData<T> toReplace, ObservableData<T> replaceWith)
        {
            int toReplaceIndex = IndexOf(toReplace);
            ReplaceAt(toReplaceIndex, replaceWith);
        }

        /// <summary>
        /// Attempts to replace the given element with the given element. 
        /// </summary>
        /// <param name="toReplaceIndex"></param>
        /// <param name="replaceWith"></param>
        public void ReplaceAt(int toReplaceIndex, ObservableData<T> replaceWith)
        {
            var toReplace = _wrapped[toReplaceIndex];
            if (Contains(toReplace) && Contains(replaceWith))
            {
                throw new InvalidOperationException("Both elements are already contained in the collection; Consider using the Move method instead");
            }
            else if (Contains(toReplace) == false)
            {
                throw new InvalidOperationException("toReplace is not contained and can thus not be replaced");
            }
            else if (Contains(replaceWith))
            {
                throw new InvalidOperationException("replaceWith is already contained and can thus not be used in replacement");
            }

            _wrapped[toReplaceIndex] = replaceWith;
            toReplace.ValueChanged -= Element_OnValueChanged;
            replaceWith.ValueChanged += Element_OnValueChanged;

            var args = new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(toReplace, toReplaceIndex, -1),
                new ElementChangedEventArgs<T>(replaceWith, -1, toReplaceIndex),
            };
            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.REPLACE, args));
            Changed?.Invoke(this);
        }

        public IEnumerator<ObservableData<T>> GetEnumerator()
        {
            return _wrapped.GetEnumerator();
        }

        /// <summary>
        /// Returns the index of the given element, if possible. If the element could not be found, returns `-1`. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ObservableData<T> item)
        {
            return _wrapped.IndexOf(item);
        }

        public IEnumerable<ObservableData<T>> GetAll()
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

            // "Move" the object by first removing and then re-inserting it at the desired index.
            var elementA = _wrapped[fromIndex];
            var elementB = _wrapped[toIndex];

            _wrapped.RemoveAt(fromIndex);
            _wrapped.RemoveAt(toIndex);

            _wrapped.Insert(fromIndex, elementB);
            _wrapped.Insert(toIndex, elementA);

            var args = new List<ElementChangedEventArgs<T>>()
            {
                new ElementChangedEventArgs<T>(elementA, fromIndex, toIndex),
                new ElementChangedEventArgs<T>(elementB, toIndex, fromIndex),
            };
            ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.MOVE, args));
            Changed?.Invoke(this);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Element_OnValueChanged(IObservableData sender, ValueChangedEventArgs<T> e)
        {
            var observableField = sender as ObservableData<T>;
            int index = IndexOf(observableField);
            this.ListChanged?.Invoke(this, new ChangedEventArgs<T>(CollectionChangeTypes.ELEMENT, new List<ElementChangedEventArgs<T>>()
                {
                    new ElementChangedEventArgs<T>(observableField, index, index, e)
                }
            ));
        }
    }
}
