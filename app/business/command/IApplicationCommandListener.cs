using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwbe.business.command
{
    /// <summary>
    /// Interface for types that can listen for application commands. 
    /// </summary>
    public interface IApplicationCommandListener
    {
        /// <summary>
        /// Notifies the listener of an emitted command. 
        /// </summary>
        /// <param name="command"></param>
        public void Notify(IApplicationCommand command);
    }
}
