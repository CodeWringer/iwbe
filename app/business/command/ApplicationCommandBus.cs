using System.Collections.Generic;

namespace iwbe.business.command
{
    /// <summary>
    /// Registers and propagates application-wide commands. 
    /// </summary>
    public class ApplicationCommandBus
    {
        /// <summary>
        /// A list of the listeners. 
        /// </summary>
        private List<IApplicationCommandListener> _listeners;

        /// <summary>
        /// Registers the given listener. 
        /// </summary>
        /// <param name="listener">The listener to register. </param>
        /// <returns>True, if the given listener could be registered. </returns>
        public bool RegisterListener(IApplicationCommandListener listener)
        {
            if (_listeners.Contains(listener))
            {
                return false;
            }
            else
            {
                _listeners.Add(listener);
                return true;
            }
        }

        /// <summary>
        /// Un-registers the given listener. 
        /// </summary>
        /// <param name="listener">The listener to un-register. </param>
        /// <returns>True, if the given listener could be un-registered. </returns>
        public bool UnregisterListener(IApplicationCommandListener listener)
        {
            return _listeners.Remove(listener);
        }

        /// <summary>
        /// Notifies all listeners of the given command. 
        /// </summary>
        /// <param name="command"></param>
        public void Execute(IApplicationCommand command)
        {
            foreach (var listener in _listeners)
            {
                listener.Notify(command);
            }
        }
    }
}
