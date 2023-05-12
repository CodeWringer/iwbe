namespace iwbe.business.util.watchable
{
    /// <summary>
    /// Encapsulates a single field of the given data type and allows listening for changes 
    /// to its value. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Watchable<T> : IWatchable
    {
        /// <summary>
        /// Invoked every time changes are made, <b>after</b> they are made. 
        /// 
        /// <br></br>
        /// 
        /// This includes changes made within this watchable. If the encapsulated value is a watchable, too, 
        /// its Changed event invocations "bubble up" through _this_ Changed event. 
        /// </summary>
        public event WatchableChangeHandler Changed;

        private T _value;
        /// <summary>
        /// The encapsulated field. 
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                if (_value is IWatchable childWatchable)
                {
                    childWatchable.Changed -= ChildWatchable_Changed;
                }
                if (value is IWatchable newChildWatchable)
                {
                    newChildWatchable.Changed += ChildWatchable_Changed;
                }
                _value = value;
                Changed?.Invoke(this);
            }
        }

        /// <summary>
        /// Passes through the child watchable's Changed event to watchers of _this_ watchable. 
        /// 
        /// This way, deeply nested watchables changing can always be watched out for, without needing 
        /// to subscribe to each one. So in a way, the Changed event "bubbles up". 
        /// </summary>
        /// <param name="watchable"></param>
        private void ChildWatchable_Changed(IWatchable watchable)
        {
            Changed?.Invoke(watchable);
        }
    }
}
