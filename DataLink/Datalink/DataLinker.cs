using System;
using System.Collections.Generic;

namespace DataLink
{
    /// <summary>
    /// Links objects of different types to each other in n:m multiplicity. 
    /// Parent and child type must not be of the same type. For that, use DataLinker<T>, instead. 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class DataLinker<T1, T2> : IDataLinker<T1, T2>
        where T1 : class
        where T2 : class
    {
        /// <summary>
        /// The links of objects of type T1. 
        /// Key: a single object of type T1. 
        /// Value: A collection of objects of type T2
        /// </summary>
        private Dictionary<T1, List<T2>> _byFirst;

        /// <summary>
        /// The links of objects of type T2. 
        /// Key: a single object of type T2. 
        /// Value: A collection of objects of type T1
        /// </summary>
        private Dictionary<T2, List<T1>> _bySecond;

        public DataLinker()
        {
            if (typeof(T1) == typeof(T2))
                throw new Exception("Types T1 and T2 must be different! If you want to create n:m links between objects of the same type, consider using DataLinker<T> instead.");

            this._byFirst = new Dictionary<T1, List<T2>>();
            this._bySecond = new Dictionary<T2, List<T1>>();
        }

        public bool Add(T1 o1, T2 o2)
        {
            bool result = false;

            if (this.Contains(o1))
            {
                var values = this._byFirst[o1];
                if (values.Contains(o2) != true)
                {
                    values.Add(o2);
                    result = true;
                }
            }
            else
            {
                var list = new List<T2>
                {
                    o2
                };
                this._byFirst.Add(o1, list);
                    result = true;
            }

            if (this.Contains(o2))
            {
                var values = this._bySecond[o2];
                if (values.Contains(o1) != true)
                {
                    values.Add(o1);
                    result = true;
                }
            }
            else
            {
                var list = new List<T1>
                {
                    o1
                };
                this._bySecond.Add(o2, list);
                result = true;
            }

            return result;
        }

        public bool Remove(T1 o1, T2 o2)
        {
            if (this.Contains(o1) != true)
                return false;

            this._byFirst[o1].Remove(o2);
            if (this._byFirst[o1].Count == 0)
                this._byFirst.Remove(o1);

            if (this.Contains(o2) != true)
                return false;

            this._bySecond[o2].Remove(o1);
            if (this._bySecond[o2].Count == 0)
                this._bySecond.Remove(o2);

            return true;
        }

        public bool Remove(T1 obj)
        {
            if (this.Contains(obj) != true)
                return false;

            var otherKeys = _byFirst[obj];
            this._byFirst.Remove(obj);

            foreach (var otherKey in otherKeys)
            {
                this._bySecond[otherKey].Remove(obj);
                if (this._bySecond[otherKey].Count == 0)
                    this._bySecond.Remove(otherKey);
            }
            return true;
        }

        public bool Remove(T2 obj)
        {
            if (this.Contains(obj) != true)
                return false;

            var otherKeys = _bySecond[obj];
            this._bySecond.Remove(obj);

            foreach (var otherKey in otherKeys)
            {
                this._byFirst[otherKey].Remove(obj);
                if (this._byFirst[otherKey].Count == 0)
                    this._byFirst.Remove(otherKey);
            }
            return true;
        }

        public void Clear()
        {
            this._byFirst = new Dictionary<T1, List<T2>>();
            this._bySecond = new Dictionary<T2, List<T1>>();
        }

        public IEnumerable<T1> GetLinksOf(T2 obj)
        {
            if (this.Contains(obj))
                return this._bySecond[obj];
            else
                return null;
        }

        public IEnumerable<T2> GetLinksOf(T1 obj)
        {
            if (this.Contains(obj))
                return this._byFirst[obj];
            else
                return null;
        }

        public IEnumerable<KeyValuePair<T1, IEnumerable<T2>>> GetAllLinksByFirst()
        {
            foreach (var kv in this._byFirst)
            {
                yield return new KeyValuePair<T1, IEnumerable<T2>>(kv.Key, kv.Value);
            }
        }

        public IEnumerable<KeyValuePair<T2, IEnumerable<T1>>> GetAllLinksBySecond()
        {
            foreach (var kv in this._bySecond)
            {
                yield return new KeyValuePair<T2, IEnumerable<T1>>(kv.Key, kv.Value);
            }
        }

        public bool Contains(T1 obj)
        {
            return this._byFirst.ContainsKey(obj);
        }

        public bool Contains(T2 obj)
        {
            return this._bySecond.ContainsKey(obj);
        }
    }

    /// <summary>
    /// Links objects of the same type to each other in n:m multiplicity. 
    /// Parent and child type must be of the same type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataLinker<T> : IDataLinker<T>
        where T : class
    {
        /// <summary>
        /// The links of objects of type T1. 
        /// Key: a single object of type T1. 
        /// Value: A collection of objects of type T2
        /// </summary>
        private Dictionary<T, List<T>> _links;

        public DataLinker()
        {
            this._links = new Dictionary<T, List<T>>();
        }

        public bool Add(T o1, T o2)
        {
            bool result = false;

            if (this._links.ContainsKey(o1) == false)
            {
                this._links.Add(o1, new List<T>() { o2 });
                result = true;
            }
            else if (this._links[o1].Contains(o2) == false)
            {
                this._links[o1].Add(o2);
                result = true;
            }

            if (this._links.ContainsKey(o2) == false)
            {
                this._links.Add(o2, new List<T>() { o1 });
                result = true;
            }
            else if (this._links[o2].Contains(o1) == false)
            {
                this._links[o2].Add(o1);
                result = true;
            }

            return result;
        }

        public bool Remove(T o1, T o2)
        {
            if (this._links.ContainsKey(o1) == false || this._links.ContainsKey(o2) == false)
                return false;

            this._links[o1].Remove(o2);
            if (this._links[o1].Count == 0)
                this._links.Remove(o1);

            this._links[o2].Remove(o1);
            if (this._links[o2].Count == 0)
                this._links.Remove(o2);

            return true;
        }

        public bool Remove(T obj)
        {
            if (this._links.ContainsKey(obj) == false)
                return false;

            var linksToRemove = new List<T>(this._links[obj]);
            foreach (var linkToRemove in linksToRemove)
            {
                this.Remove(linkToRemove, obj);
            }

            return true;
        }

        public void Clear()
        {
            this._links = new Dictionary<T, List<T>>();
        }

        public IEnumerable<T> GetLinksOf(T obj)
        {
            if (this._links.ContainsKey(obj))
                return this._links[obj];
            else
                return null;
        }

        public bool Contains(T obj)
        {
            return this._links.ContainsKey(obj);
        }
    }
}