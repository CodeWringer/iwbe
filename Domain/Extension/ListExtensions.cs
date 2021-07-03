using System;
using System.Collections.Generic;

namespace Iwbe
{
    public static class ListExtensions
    {
        /// <summary>
        /// Adds or inserts the given item with regards to the ordering of the list, relying on the 
        /// items of the list to be comparable. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="item"></param>
        public static void AddSorted<T>(this List<T> @this, T item) where T : IComparable<T>
        {
            if (@this.Count == 0)
            {
                @this.Add(item);
                return;
            }
            if (@this[@this.Count - 1].CompareTo(item) <= 0)
            {
                @this.Add(item);
                return;
            }
            if (@this[0].CompareTo(item) >= 0)
            {
                @this.Insert(0, item);
                return;
            }
            int index = @this.BinarySearch(item);
            if (index < 0)
                index = ~index;
            @this.Insert(index, item);
        }

        /// <summary>
        /// Adds or inserts the given item with regards to the ordering of the list, using the given 
        /// comparer to determine the order. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="item"></param>
        /// <param name="comparer"></param>
        public static void AddSorted<T>(this List<T> @this, T item, IComparer<T> comparer)
        {
            if (@this.Count == 0)
            {
                @this.Add(item);
                return;
            }
            if (comparer.Compare(@this[@this.Count - 1], item) <= 0)
            {
                @this.Add(item);
                return;
            }
            if (comparer.Compare(@this[0], item) >= 0)
            {
                @this.Insert(0, item);
                return;
            }
            int index = @this.BinarySearch(item, comparer);
            if (index < 0)
                index = ~index;
            @this.Insert(index, item);
        }
    }
}