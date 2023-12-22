namespace iwbe.common.observables
{
    /// <summary>
    /// Represents business data whose changes can be observed. 
    /// </summary>
    public interface IObservableData
    {
        public delegate void onChangedHandler(IObservableData sender);

        public event onChangedHandler OnChanged;
    }
}
