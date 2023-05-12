using iwbe.business.state;

namespace iwbe.business.command
{
    /// <summary>
    /// Represents an application-level command. 
    /// 
    /// <br></br>
    /// 
    /// A command typically causes alteration of the business model state or presentation model state (like prompting the user to action 
    /// or changing the current view) or reading and writing data. 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Invokes the command, thus executing it. 
        /// </summary>
        public void Invoke();
    }
}
