using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a tag, linkable to taggable objects. 
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Unique id. 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Name/text of the tag. 
        /// </summary>
        public string Name;

        public Tag(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
