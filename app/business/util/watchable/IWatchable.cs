namespace iwbe.business.util.watchable
{
    /// <summary>
    /// Handles an event of a watchable's value being modified. 
    /// </summary>
    /// <param name="watchable">The instance that was modified. </param>
    public delegate void WatchableChangeHandler(IWatchable watchable);

    /// <summary>
    /// Marks a type whose field changes can be watched for through this interface. 
    /// </summary>
    public interface IWatchable
    {
        /// <summary>
        /// Invoked every time changes are made, <b>after</b> they are made. 
        /// </summary>
        public event WatchableChangeHandler Changed;
    }
}
