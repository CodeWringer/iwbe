using System;
using System.Collections.Generic;

namespace iwbe.business.util
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<KeyValuePair<T1, T2>> ToKeyValuePairs<T1, T2>(this Dictionary<T1, T2> @this)
        {
            return new List<KeyValuePair<T1, T2>>(@this);
        }
    }
}