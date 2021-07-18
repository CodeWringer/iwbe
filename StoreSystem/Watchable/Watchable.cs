namespace DataStore
{
    public class Watchable<T> : IWatchable<T>
    {
        public event WatchableChanging<T> Changing;
        public event WatchableChanged<T> Changed;

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                T oldValue = _value;
                Changing?.Invoke(this, value, oldValue);
                _value = value;
                Changed?.Invoke(this, Value, oldValue);
            }
        }
    }
}