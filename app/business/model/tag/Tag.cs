using System;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a tag linkable to taggable objects. 
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Unique ID of this Tag. 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// A user defined text to display for this tag. 
        /// </summary>
        public string Text;

        public Tag(Guid id)
        {
            Id = id;
        }

        public Tag(Guid id, string text) : this(id)
        {
            Text = text;
        }
    }
}