using System.Collections.Generic;

namespace iwbe.business.util.watchable
{
    /// <summary>
    /// Wraps the watchable that was changed. 
    /// </summary>
    public class WatchableChangedEventArgs
    {
        /// <summary>
        /// The watchable that was changed. 
        /// </summary>
        public IWatchable Watchable { get; private set; }

        public WatchableChangedEventArgs(IWatchable watchable)
        {
            Watchable = watchable;
        }
    }

    /// <summary>
    /// Wraps the changes to a single value field. 
    /// </summary>
    /// <typeparam name="T">Data type of the field that was changed. </typeparam>
    public class WatchableFieldChangedEventArgs<T> : WatchableChangedEventArgs
    {
        /// <summary>
        /// The value of the field before the change. 
        /// </summary>
        public T OldValue { get; private set; }

        /// <summary>
        /// The value of the field after the change. 
        /// </summary>
        public T NewValue { get; private set; }

        public WatchableFieldChangedEventArgs(IWatchable watchable, T oldValue, T newValue)
            : base(watchable)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    /// <summary>
    /// Represents the ways in which a watchable collection could be or has been changed. 
    /// </summary>
    public enum WatchableCollectionChangedType
    {
        /// <summary>
        /// Elements were added. 
        /// </summary>
        ADD,
        /// <summary>
        /// Elements were removed. 
        /// </summary>
        REMOVE,
        /// <summary>
        /// Elements were moved. 
        /// </summary>
        MOVE,
        /// <summary>
        /// Elements were edited. 
        /// </summary>
        EDIT,
    }

    /// <summary>
    /// Wraps the changes to a collection. 
    /// </summary>
    /// <typeparam name="T">Data type of the elements of the collection. </typeparam>
    public class WatchableCollectionChangedEventArgs<T> : WatchableChangedEventArgs
    {
        /// <summary>
        /// The element(s) that were changed. 
        /// </summary>
        public IEnumerable<T> Elements { get; private set; }

        /// <summary>
        /// The indices of elements prior to the change. 
        /// </summary>
        public IEnumerable<KeyValuePair<T, long>> OldIndices { get; private set; }

        /// <summary>
        /// The indices of elements after the change. 
        /// </summary>
        public IEnumerable<KeyValuePair<T, long>> NewIndices { get; private set; }

        /// <summary>
        /// Represents the way in which the collection was changed. 
        /// </summary>
        public WatchableCollectionChangedType ChangeType { get; private set; }

        public WatchableCollectionChangedEventArgs(
            IWatchable watchable,
            IEnumerable<T> elements,
            IEnumerable<KeyValuePair<T, long>> oldIndices,
            IEnumerable<KeyValuePair<T, long>> newIndices,
            WatchableCollectionChangedType changeType
        )
            : base(watchable)
        {
            Elements = elements;
            OldIndices = oldIndices;
            NewIndices = newIndices;
            ChangeType = changeType;
        }
    }
}
