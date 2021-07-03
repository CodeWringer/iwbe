using DataLink;
using System;
using System.Collections.Generic;

namespace StoreSystem
{
    /// <summary>
    /// Links objects to each other in 1:n multiplicity. 
    /// Parent and child type can be of the same type. 
    /// 
    /// Exposes events to allow observing changes. 
    /// </summary>
    /// <typeparam name="T1">Parent object type. </typeparam>
    /// <typeparam name="T2">Child object type. </typeparam>
    public class ObservableHierarchyDataLinker<T1, T2> : IObservableHierarchyDataLinker<T1, T2>, IHierarchyDataLinker<T1, T2>
        where T1 : class
        where T2 : class
    {
        public event WatchableHierarchyDataLinkAddHandler<T1, T2> ItemAdding;
        public event WatchableHierarchyDataLinkAddHandler<T1, T2> ItemAdded;

        public event WatchableHierarchyDataLinkRemoveParentHandler<T1, T2> ParentRemoving;
        public event WatchableHierarchyDataLinkRemoveParentHandler<T1, T2> ParentRemoved;

        public event WatchableHierarchyDataLinkRemoveChildHandler<T1, T2> ChildRemoving;
        public event WatchableHierarchyDataLinkRemoveChildHandler<T1, T2> ChildRemoved;

        public event EventHandler Clearing;
        public event EventHandler Cleared;

        private HierarchyDataLinker<T1, T2> _wrapped = new HierarchyDataLinker<T1, T2>();

        public void Add(T1 parent, T2 child)
        {
            var change = new HierarchyLinkAddChange<T1, T2>(parent, child);
            ItemAdding?.Invoke(this, change);
            _wrapped.Add(parent, child);
            ItemAdded?.Invoke(this, change);
        }

        public bool RemoveChild(T2 child)
        {
            var parent = GetParentOf(child);
            var change = new HierarchyLinkRemoveChildChange<T1, T2>(parent, child);
            ChildRemoving?.Invoke(this, change);
            if (_wrapped.RemoveChild(child))
            {
                ChildRemoved?.Invoke(this, change);
                return true;
            }
            return false;
        }

        public bool RemoveParent(T1 parent)
        {
            var change = new HierarchyLinkRemoveParentChange<T1, T2>(parent, GetChildrenOf(parent));
            ParentRemoving?.Invoke(this, change);
            if (_wrapped.RemoveParent(parent))
            {
                ParentRemoved?.Invoke(this, change);
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

        public bool ContainsChild(T2 child)
        {
            return _wrapped.ContainsChild(child);
        }

        public bool ContainsParent(T1 parent)
        {
            return _wrapped.ContainsParent(parent);
        }

        public IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinks()
        {
            return _wrapped.GetAllLinks();
        }

        public IEnumerable<T2> GetChildrenOf(T1 parent)
        {
            return _wrapped.GetChildrenOf(parent);
        }

        public T1 GetParentOf(T2 child)
        {
            return _wrapped.GetParentOf(child);
        }
    }

    /// <summary>
    /// Links objects to each other in 1:n multiplicity. 
    /// Parent and child type are of the same type. 
    /// 
    /// Exposes events to allow observing changes. 
    /// </summary>
    /// <typeparam name="T">Parent and child object type. </typeparam>
    public class ObservableHierarchyDataLinker<T> : ObservableHierarchyDataLinker<T, T>
        where T : class
    {
    }
}
