using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwbe.business.command
{
    /// <summary>
    /// An application-level command. 
    /// 
    /// <br></br>
    /// 
    /// This could be any business or presentation state altering command, like  
    /// adding, removing, altering or moving business data or switching active view.
    /// </summary>
    public interface IApplicationCommand
    {
        /// <summary>
        /// Name of the command to execute. 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Executes the command. 
        /// </summary>
        public void Execute();
    }
}
