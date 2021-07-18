using DataLink;
using System;
using System.Collections.Generic;

namespace DataStore
{
    /// <summary>
    /// Links objects of different types to each other in n:m multiplicity. 
    /// Parent and child type must not be of the same type. For that, use ObservableDataLinker<T>, instead. 
    /// 
    /// Exposes events to allow observing changes. 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class ObservableDataLinker<T1, T2> : IObservableDataLinker<T1, T2>, IDataLinker<T1, T2>
        where T1 : class
        where T2 : class
    {
        public event WatchableDataLinkAddHandler<T1, T2> ItemAdding;
        public event WatchableDataLinkAddHandler<T1, T2> ItemAdded;

        public event WatchableDataLinkRemoveHandler<T1, T2> ItemRemoving;
        public event WatchableDataLinkRemoveHandler<T1, T2> ItemRemoved;

        public event WatchableDataLinkRemoveAllByFirstHandler<T1, T2> ItemRemovingAllByFirst;
        public event WatchableDataLinkRemoveAllByFirstHandler<T1, T2> ItemRemovedAllByFirst;

        public event WatchableDataLinkRemoveAllBySecondHandler<T1, T2> ItemRemovingAllBySecond;
        public event WatchableDataLinkRemoveAllBySecondHandler<T1, T2> ItemRemovedAllBySecond;

        public event EventHandler Clearing;
        public event EventHandler Cleared;

        private DataLinker<T1, T2> _wrapped;

        public ObservableDataLinker()
        {
            if (typeof(T1) == typeof(T2))
                throw new Exception("Types T1 and T2 must be different! If you want to create n:m links between objects of the same type, consider using DataLinker<T> instead.");

            this._wrapped = new DataLinker<T1, T2>();
        }

        public bool Add(T1 o1, T2 o2)
        {
            var change = new LinkAddRemoveChange<T1, T2>(o1, o2);
            ItemAdding?.Invoke(this, change);
            if (_wrapped.Add(o1, o2))
            {
                ItemAdded?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool Remove(T1 o1, T2 o2)
        {
            var change = new LinkAddRemoveChange<T1, T2>(o1, o2);
            ItemRemoving?.Invoke(this, change);
            if (_wrapped.Remove(o1, o2))
            {
                ItemRemoved?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool Remove(T1 obj)
        {
            var change = new LinkRemoveAllByFirstChange<T1, T2>(obj, GetLinksOf(obj));
            ItemRemovingAllByFirst?.Invoke(this, change);
            if (_wrapped.Remove(obj))
            {
                ItemRemovedAllByFirst?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool Remove(T2 obj)
        {
            var change = new LinkRemoveAllBySecondChange<T1, T2>(obj, GetLinksOf(obj));
            ItemRemovingAllBySecond?.Invoke(this, change);
            if (_wrapped.Remove(obj))
            {
                ItemRemovedAllBySecond?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            Clearing?.Invoke(this, new EventArgs());
            _wrapped.Clear();
            Cleared?.Invoke(this, new EventArgs());
        }

        public IEnumerable<T1> GetLinksOf(T2 obj)
        {
            return _wrapped.GetLinksOf(obj);
        }

        public IEnumerable<T2> GetLinksOf(T1 obj)
        {
            return _wrapped.GetLinksOf(obj);
        }

        public IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinksByFirst()
        {
            return _wrapped.GetAllLinksByFirst();
        }

        public IEnumerable<KeyValuePair<T2, IEnumerable<T1>>> GetAllLinksBySecond()
        {
            return _wrapped.GetAllLinksBySecond();
        }

        public bool Contains(T1 obj)
        {
            return _wrapped.Contains(obj);
        }

        public bool Contains(T2 obj)
        {
            return _wrapped.Contains(obj);
        }
    }

    /// <summary>
    /// Links objects of the same type to each other in n:m multiplicity. 
    /// Parent and child type must be of the same type.
    /// 
    /// Exposes events to allow observing changes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableDataLinker<T> : IObservableDataLinker<T>, IDataLinker<T>
        where T : class
    {
        public event WatchableDataLinkAddHandler<T> ItemAdding;
        public event WatchableDataLinkAddHandler<T> ItemAdded;

        public event WatchableDataLinkRemoveHandler<T> ItemRemoving;
        public event WatchableDataLinkRemoveHandler<T> ItemRemoved;

        public event WatchableDataLinkRemoveAllHandler<T> ItemRemovingAll;
        public event WatchableDataLinkRemoveAllHandler<T> ItemRemovedAll;

        public event EventHandler Clearing;
        public event EventHandler Cleared;

        private DataLinker<T> _wrapped = new DataLinker<T>();

        public bool Add(T o1, T o2)
        {
            var change = new LinkAddRemoveChange<T>(o1, o2);
            ItemAdding?.Invoke(this, change);
            if (_wrapped.Add(o1, o2))
            {
                ItemAdded?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool Remove(T o1, T o2)
        {
            var change = new LinkAddRemoveChange<T>(o1, o2);
            ItemRemoving?.Invoke(this, change);
            if (_wrapped.Remove(o1, o2))
            {
                ItemRemoved?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool Remove(T obj)
        {
            var change = new LinkRemoveAllChange<T>(obj, _wrapped.GetLinksOf(obj));
            ItemRemovingAll?.Invoke(this, change);
            if (_wrapped.Remove(obj))
            {
                ItemRemovedAll?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            Clearing?.Invoke(this, new EventArgs());
            _wrapped.Clear();
            Cleared?.Invoke(this, new EventArgs());
        }

        public IEnumerable<T> GetLinksOf(T obj)
        {
            return _wrapped.GetLinksOf(obj);
        }

        public bool Contains(T obj)
        {
            return _wrapped.Contains(obj);
        }
    }
}
