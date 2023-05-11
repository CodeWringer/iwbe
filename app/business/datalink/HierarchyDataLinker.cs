using System;
using System.Collections.Generic;

namespace iwbe.business.datalink
{
    /// <summary>
    /// Links objects to each other in 1:n multiplicity. 
    /// Parent and child type can be of the same type. 
    /// </summary>
    /// <typeparam name="T1">Parent object type. </typeparam>
    /// <typeparam name="T2">Child object type. </typeparam>
    public class HierarchyDataLinker<T1, T2> : IHierarchyDataLinker<T1, T2>
        where T1 : class
        where T2 : class
    {
        /// <summary>
        /// The parent objects and their children. 
        /// </summary>
        protected Dictionary<T1, List<T2>> _parentsToChildren;

        /// <summary>
        /// The children and their parent. 
        /// </summary>
        protected Dictionary<T2, T1> _childrenToParents;

        public HierarchyDataLinker()
        {
            this._parentsToChildren = new Dictionary<T1, List<T2>>();
            this._childrenToParents = new Dictionary<T2, T1>();
        }

        public void Add(T1 parent, T2 child)
        {
            if (parent == child)
                throw new ArgumentException("The given parent and child object mustn't be the same object!");

            this.RemoveChild(child);
            this._childrenToParents.Add(child, parent);

            if (this.ContainsParent(parent))
            {
                this._parentsToChildren[parent].Add(child);
            }
            else
            {
                var list = new List<T2> { child };
                this._parentsToChildren.Add(parent, list);
            }
        }

        public bool RemoveChild(T2 child)
        {
            if (this.ContainsChild(child) == false)
                return false;

            var parent = this._childrenToParents[child];
            this._childrenToParents.Remove(child);

            this._parentsToChildren[parent].Remove(child);
            if (this._parentsToChildren[parent].Count == 0)
                this._parentsToChildren.Remove(parent);

            return true;
        }

        public bool RemoveParent(T1 parent)
        {
            if (this.ContainsParent(parent) == false)
                return false;

            foreach (var child in this._parentsToChildren[parent])
            {
                this._childrenToParents.Remove(child);
            }
            this._parentsToChildren.Remove(parent);

            return true;
        }

        public void Clear()
        {
            this._parentsToChildren = new Dictionary<T1, List<T2>>();
            this._childrenToParents = new Dictionary<T2, T1>();
        }

        public IEnumerable<T2> GetChildrenOf(T1 parent)
        {
            if (this.ContainsParent(parent))
                return this._parentsToChildren[parent].ToArray();
            else
                return null;
        }

        public T1 GetParentOf(T2 child)
        {
            if (this.ContainsChild(child))
                return this._childrenToParents[child];
            else
                return default;
        }

        public bool ContainsParent(T1 parent)
        {
            return this._parentsToChildren.ContainsKey(parent);
        }

        public bool ContainsChild(T2 child)
        {
            return this._childrenToParents.ContainsKey(child);
        }

        public IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinks()
        {
            foreach (var kv in this._parentsToChildren)
            {
                yield return new KeyValuePair<T1, IEnumerable<T2>>(kv.Key, kv.Value);
            }
        }
    }

    /// <summary>
    /// Links objects to each other in 1:n multiplicity. 
    /// Parent and child type are of the same type. 
    /// </summary>
    /// <typeparam name="T">Parent and child object type. </typeparam>
    public class HierarchyDataLinker<T> : HierarchyDataLinker<T, T>
        where T : class
    {
    }
}
