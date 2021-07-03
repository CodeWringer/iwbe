namespace StoreSystem
{
    public delegate void WatchableChanging(IWatchable watchable, object newValue, object oldValue);
    public delegate void WatchableChanged(IWatchable watchable, object newValue, object oldValue);

    public delegate void WatchableChanging<T>(IWatchable<T> watchable, T newValue, T oldValue);
    public delegate void WatchableChanged<T>(IWatchable<T> watchable, T newValue, T oldValue);

    public interface IWatchable
    {
        event WatchableChanging Changing;
        event WatchableChanged Changed;
    }

    public interface IWatchable<T>
    {
        event WatchableChanging<T> Changing;
        event WatchableChanged<T> Changed;
    }
}