namespace iwbe.common.observables
{
    public class ValueChangedEventArgs<T>
    {
        public T OldValue { get; private set; }

        public T NewValue { get; private set; }

        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    /// <summary>
    /// Represents a field on an object, whose value changes can be observed/listened for. 
    /// 
    /// Wraps a single value. 
    /// </summary>
    public class ObservableData<T> : IObservableData
    {
        public delegate void ValueChangedHandler(IObservableData sender, ValueChangedEventArgs<T> e);

        public event ValueChangedHandler ValueChanged;
        public event IObservableData.ChangedHandler Changed;

        private T _value;
        /// <summary>
        /// The wrapped value whose changes can be observed. Assigning a value via this accessor causes 
        /// the OnChanged and OnValueChanged events to be fired. 
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                var oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ValueChangedEventArgs<T>(oldValue, value));
                Changed?.Invoke(this);
            }
        }

        public ObservableData()
        {
            _value = default;
        }

        public ObservableData(T value)
        {
            _value = value;
        }
    }
}
