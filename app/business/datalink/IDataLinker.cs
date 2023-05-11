using System.Collections.Generic;

namespace iwbe.business.datalink
{
    public interface IDataLinker<T1, T2>
    {
        /// <summary>
        /// Adds a link between the two given objects, if possible. 
        /// 
        /// Returns false, if a link between the two given objects already exists. 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns>True, if a new link could be added. </returns>
        bool Add(T1 o1, T2 o2);

        /// <summary>
        /// Removes a link between the two given objects, if possible. 
        /// 
        /// Returns false, if no link between the two given objects exists. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>True, if a link could be removed. </returns>
        bool Remove(T1 o1, T2 o2);

        /// <summary>
        /// Removes all links of the given object, if possible. 
        /// 
        /// Returns false, if the given object has no links. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True, if there was at least one link to remove. </returns>
        bool Remove(T1 obj);

        /// <summary>
        /// Removes all links of the given object, if possible. 
        /// 
        /// Returns false, if the given object has no links. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True, if there was at least one link to remove. </returns>
        bool Remove(T2 obj);

        /// <summary>
        /// Clears all links. 
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns all linked objects of the given object. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>All linked objects of the given object.</returns>
        IEnumerable<T1> GetLinksOf(T2 obj);

        /// <summary>
        /// Returns all linked objects of the given object. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>All linked objects of the given object.</returns>
        IEnumerable<T2> GetLinksOf(T1 obj);

        /// <summary>
        /// Returns all links, from the viewpoint of the objects of type {T1}. 
        /// </summary>
        /// <returns>All links, from the viewpoint of the objects of type {T1}. </returns>
        IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinksByFirst();

        /// <summary>
        /// Returns all links, from the viewpoint of the objects of type {T2}. 
        /// </summary>
        /// <returns>All links, from the viewpoint of the objects of type {T2}. </returns>
        IEnumerable<KeyValuePair<T2, IEnumerable<T1>>> GetAllLinksBySecond();

        /// <summary>
        /// Returns all links. 
        /// </summary>
        /// <returns>An object that contains all the links, from either viewpoint. </returns>
        ReadOnlyDataLinks<T1, T2> GetAllLinks();

        /// <summary>
        /// Returns true, if the given object has at least one link. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Contains(T1 obj);

        /// <summary>
        /// Returns true, if the given object has at least one link. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Contains(T2 obj);
    }

    public interface IDataLinker<T>
    {
        /// <summary>
        /// Adds a link between the two given objects, if possible. 
        /// 
        /// Returns false, if a link between the two given objects already exists. 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns>True, if a new link could be added. </returns>
        bool Add(T o1, T o2);

        /// <summary>
        /// Removes a link between the two given objects, if possible. 
        /// 
        /// Returns false, if no link between the two given objects exists. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>True, if a link could be removed. </returns>
        bool Remove(T o1, T o2);

        /// <summary>
        /// Removes all links of the given object, if possible. 
        /// 
        /// Returns false, if the given object has no links. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True, if there was at least one link to remove. </returns>
        bool Remove(T obj);

        /// <summary>
        /// Clears all links. 
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns all linked objects of the given object. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>All linked objects of the given object.</returns>
        IEnumerable<T> GetLinksOf(T obj);

        /// <summary>
        /// Returns true, if the given object has at least one link. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Contains(T obj);
    }
}
