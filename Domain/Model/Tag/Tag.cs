using StoreSystem;
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

        public Watchable<string> NameWatchable = new Watchable<string>();
        /// <summary>
        /// Name/text of the tag. 
        /// </summary>
        public string Name
        {
            get => NameWatchable.Value;
            set => NameWatchable.Value = value;
        }

        public Tag(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
