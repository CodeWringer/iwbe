namespace iwbe.common.observables
{
    /// <summary>
    /// Represents business data whose changes can be observed. 
    /// </summary>
    public interface IObservableData
    {
        public delegate void ChangedHandler(IObservableData sender);

        public event ChangedHandler Changed;
    }
}
