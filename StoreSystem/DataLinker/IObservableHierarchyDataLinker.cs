using System;
using System.Collections.Generic;

namespace DataStore
{
    public delegate void WatchableHierarchyDataLinkAddHandler<T1, T2>(IObservableHierarchyDataLinker<T1, T2> watchable, HierarchyLinkAddChange<T1, T2> change);
    public delegate void WatchableHierarchyDataLinkRemoveParentHandler<T1, T2>(IObservableHierarchyDataLinker<T1, T2> watchable, HierarchyLinkRemoveParentChange<T1, T2> change);
    public delegate void WatchableHierarchyDataLinkRemoveChildHandler<T1, T2>(IObservableHierarchyDataLinker<T1, T2> watchable, HierarchyLinkRemoveChildChange<T1, T2> change);

    public interface IObservableHierarchyDataLinker<T1, T2>
    {
        event WatchableHierarchyDataLinkAddHandler<T1, T2> ItemAdding;
        event WatchableHierarchyDataLinkAddHandler<T1, T2> ItemAdded;

        event WatchableHierarchyDataLinkRemoveParentHandler<T1, T2> ParentRemoving;
        event WatchableHierarchyDataLinkRemoveParentHandler<T1, T2> ParentRemoved;

        event WatchableHierarchyDataLinkRemoveChildHandler<T1, T2> ChildRemoving;
        event WatchableHierarchyDataLinkRemoveChildHandler<T1, T2> ChildRemoved;

        event EventHandler Clearing;
        event EventHandler Cleared;
    }

    public struct HierarchyLinkAddChange<T1, T2>
    {
        public T1 Parent { get; private set; }
        public T2 Child { get; private set; }

        public HierarchyLinkAddChange(T1 parent, T2 child)
        {
            this.Parent = parent;
            this.Child = child;
        }
    }

    public struct HierarchyLinkRemoveParentChange<T1, T2>
    {
        public T1 Parent { get; private set; }
        public IEnumerable<T2> Children { get; private set; }

        public HierarchyLinkRemoveParentChange(T1 parent, IEnumerable<T2> children)
        {
            this.Parent = parent;
            this.Children = children;
        }
    }

    public struct HierarchyLinkRemoveChildChange<T1, T2>
    {
        public T1 Parent { get; private set; }
        public T2 Child { get; private set; }

        public HierarchyLinkRemoveChildChange(T1 parent, T2 child)
        {
            this.Parent = parent;
            this.Child = child;
        }
    }
}
