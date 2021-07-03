namespace StateHistory
{
    public interface ICommandReverser
    {
        /// <summary>
        /// Returns a new mutation that could revert the change(s) of the given mutation, if possible. 
        /// The returned mutation is not automatically applied! It must be dispatched like any normal mutation. 
        /// Returns null, if this store couldn't revert the given mutation. 
        /// </summary>
        /// <param name="command">A command to revert. </param>
        /// <returns>A reverted mutation, based on the given mutation, or null, if it couldn't be reverted. </returns>
        ICommand GetRevertedMutation(ICommand command);
    }
}
