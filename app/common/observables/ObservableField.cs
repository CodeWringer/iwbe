namespace iwbe.common.observables
{
    /// <summary>
    /// Represents a field on an object, whose value changes can be observed/listened for. 
    /// 
    /// Wraps a single value. 
    /// </summary>
    public class ObservableField<T> : IObservableData
    {
        public delegate void onValueChangedHandler(IObservableData sender, T oldValue, T newValue);

        public event onValueChangedHandler OnValueChanged;
        public event IObservableData.onChangedHandler OnChanged;

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
                OnValueChanged?.Invoke(this, oldValue, value);
                OnChanged?.Invoke(this);
            }
        }

        public ObservableField()
        {
            _value = default;
        }

        public ObservableField(T value)
        {
            _value = value;
        }
    }
}
