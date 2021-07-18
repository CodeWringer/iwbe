using System;
using System.Collections.Generic;

namespace DataStore
{
    // Two differing types
    public delegate void WatchableDataLinkAddHandler<T1, T2>(IObservableDataLinker<T1, T2> watchable, LinkAddRemoveChange<T1, T2> change);
    public delegate void WatchableDataLinkRemoveHandler<T1, T2>(IObservableDataLinker<T1, T2> watchable, LinkAddRemoveChange<T1, T2> change);
    public delegate void WatchableDataLinkRemoveAllByFirstHandler<T1, T2>(IObservableDataLinker<T1, T2> watchable, LinkRemoveAllByFirstChange<T1, T2> change);
    public delegate void WatchableDataLinkRemoveAllBySecondHandler<T1, T2>(IObservableDataLinker<T1, T2> watchable, LinkRemoveAllBySecondChange<T1, T2> change);

    public interface IObservableDataLinker<T1, T2>
    {
        event WatchableDataLinkAddHandler<T1, T2> ItemAdding;
        event WatchableDataLinkAddHandler<T1, T2> ItemAdded;

        event WatchableDataLinkRemoveHandler<T1, T2> ItemRemoving;
        event WatchableDataLinkRemoveHandler<T1, T2> ItemRemoved;

        event WatchableDataLinkRemoveAllByFirstHandler<T1, T2> ItemRemovingAllByFirst;
        event WatchableDataLinkRemoveAllByFirstHandler<T1, T2> ItemRemovedAllByFirst;

        event WatchableDataLinkRemoveAllBySecondHandler<T1, T2> ItemRemovingAllBySecond;
        event WatchableDataLinkRemoveAllBySecondHandler<T1, T2> ItemRemovedAllBySecond;

        event EventHandler Clearing;
        event EventHandler Cleared;
    }

    public struct LinkAddRemoveChange<T1, T2>
    {
        public T1 Object1 { get; private set; }
        public T2 Object2 { get; private set; }

        public LinkAddRemoveChange(T1 object1, T2 object2)
        {
            this.Object1 = object1;
            this.Object2 = object2;
        }
    }

    public struct LinkRemoveAllByFirstChange<T1, T2>
    {
        public T1 Object { get; private set; }
        public IEnumerable<T2> Links { get; private set; }

        public LinkRemoveAllByFirstChange(T1 @object, IEnumerable<T2> links)
        {
            this.Object = @object;
            this.Links = links;
        }
    }

    public struct LinkRemoveAllBySecondChange<T1, T2>
    {
        public T2 Object { get; private set; }
        public IEnumerable<T1> Links { get; private set; }

        public LinkRemoveAllBySecondChange(T2 @object, IEnumerable<T1> links)
        {
            this.Object = @object;
            this.Links = links;
        }
    }

    // Same type
    public delegate void WatchableDataLinkAddHandler<T>(IObservableDataLinker<T> watchable, LinkAddRemoveChange<T> change);
    public delegate void WatchableDataLinkRemoveHandler<T>(IObservableDataLinker<T> watchable, LinkAddRemoveChange<T> change);
    public delegate void WatchableDataLinkRemoveAllHandler<T>(IObservableDataLinker<T> watchable, LinkRemoveAllChange<T> change);

    public interface IObservableDataLinker<T>
    {
        event WatchableDataLinkAddHandler<T> ItemAdding;
        event WatchableDataLinkAddHandler<T> ItemAdded;

        event WatchableDataLinkRemoveHandler<T> ItemRemoving;
        event WatchableDataLinkRemoveHandler<T> ItemRemoved;

        event WatchableDataLinkRemoveAllHandler<T> ItemRemovingAll;
        event WatchableDataLinkRemoveAllHandler<T> ItemRemovedAll;

        event EventHandler Clearing;
        event EventHandler Cleared;
    }

    public struct LinkAddRemoveChange<T>
    {
        public T Object1 { get; private set; }
        public T Object2 { get; private set; }

        public LinkAddRemoveChange(T object1, T object2)
        {
            this.Object1 = object1;
            this.Object2 = object2;
        }
    }

    public struct LinkRemoveAllChange<T>
    {
        public T Object { get; private set; }
        public IEnumerable<T> Links { get; private set; }

        public LinkRemoveAllChange(T @object, IEnumerable<T> links)
        {
            this.Object = @object;
            this.Links = links;
        }
    }
}