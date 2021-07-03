namespace StateHistory
{
    public interface IStateOverrideable
    {
        void SetState(object state);

        object GetState();
    }
}
