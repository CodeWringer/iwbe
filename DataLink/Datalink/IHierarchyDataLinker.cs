using System.Collections.Generic;

namespace DataLink
{
    /// <summary>
    /// Links objects to each other in 1:n multiplicity. 
    /// Parent and child type can be of the same type. 
    /// </summary>
    /// <typeparam name="T1">Parent object type. </typeparam>
    /// <typeparam name="T2">Child object type. </typeparam>
    public interface IHierarchyDataLinker<T1, T2>
        where T1 : class
        where T2 : class
    {
        /// <summary>
        /// Adds the given child to the given parent. 
        /// If the child already has a parent, it is detached, first. 
        /// 
        /// Attempting to add the same object to itself as a parent results in an ArgumentException. 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <exception cref="System.ArgumentException">Thrown, if the given parent and child objects are the same object. </exception>
        void Add(T1 parent, T2 child);

        /// <summary>
        /// Detaches the given child from its parent. 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        bool RemoveChild(T2 child);

        /// <summary>
        /// Detaches the given parent from all its children. 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        bool RemoveParent(T1 parent);

        /// <summary>
        /// Resets the collection and clears all parent-child connections. 
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns all children of the given parent. 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        IEnumerable<T2> GetChildrenOf(T1 parent);

        /// <summary>
        /// Returns the parent of the given child. 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        T1 GetParentOf(T2 child);

        /// <summary>
        /// Returns true, if the given object is a key. 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        bool ContainsParent(T1 parent);

        /// <summary>
        /// Returns true, if the given object is a key. 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        bool ContainsChild(T2 child);

        /// <summary>
        /// Returns all links, from the viewpoint of the parent objects. 
        /// 
        /// The keys (= parents) are of type {T1}, their values (= children) are of type IEnumerables<{T2}>. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinks();
    }
}