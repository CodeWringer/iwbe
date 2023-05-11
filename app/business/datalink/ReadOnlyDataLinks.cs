using Godot;
using System.Collections.Generic;

namespace iwbe.business.datalink
{

    /// <summary>
    /// A read-only representation of a DataLinker's data. 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class ReadOnlyDataLinks<T1, T2>
    {
        /// <summary>
        /// The links of objects of type T1. 
        /// Key: a single object of type T1. 
        /// Value: A collection of objects of type T2
        /// </summary>
        public IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> ByFirst { get; private set; }

        /// <summary>
        /// The links of objects of type T2. 
        /// Key: a single object of type T2. 
        /// Value: A collection of objects of type T1
        /// </summary>
        public IEnumerable<KeyValuePair<T2, IEnumerable<T1>>> BySecond { get; private set; }

        public ReadOnlyDataLinks(IDataLinker<T1, T2> dataLinker)
        {
            ByFirst = dataLinker.GetAllLinksByFirst();
            BySecond = dataLinker.GetAllLinksBySecond();
        }
    }
}