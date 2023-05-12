namespace iwbe.business.command
{
    /// <summary>
    /// Handles an event of a command being dispatched. 
    /// </summary>
    /// <param name="command"></param>
    public delegate void CommandDispatchedHandler(ICommand command);

    /// <summary>
    /// Represents a central point of interaction, via which to dispatch commands that may alter the business model state, 
    /// prompt the user to action, read and write data or perform any other application-level operation. 
    /// 
    /// <br></br>
    /// 
    /// Also allows listening for commands being dispatched, so that the application may react. 
    /// </summary>
    public class CommandDispatcher
    {
        /// <summary>
        /// Invoked <b>after</b> a command is dispatched. 
        /// </summary>
        public event CommandDispatchedHandler CommandDispatched;

        /// <summary>
        /// Dispatches and thus executes the given command. 
        /// 
        /// <br></br>
        /// 
        /// This operation can be listened for via the CommandDispatched event. 
        /// </summary>
        /// <param name="command"></param>
        public void Dispatch(ICommand command)
        {
            command.Invoke();
            CommandDispatched?.Invoke(command);
        }
    }
}
