using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Marks an object as taggable. 
    /// </summary>
    public interface ITaggable
    {
        /// <summary>
        /// Returns all current tags of this object. 
        /// </summary>
        IEnumerable<Tag> Tags { get; }

        /// <summary>
        /// Adds the given tag to this object. 
        /// 
        /// Will not add the same tag twice - duplicates will not be created!
        /// </summary>
        /// <param name="tag">The tag to add. </param>
        /// <returns></returns>
        void AddTag(Tag tag);

        /// <summary>
        /// Removes the given tag from this object, if possible. 
        /// 
        /// Returns true, if successful. 
        /// </summary>
        /// <param name="tag">The tag to remove. </param>
        /// <returns>True, if the tag was removed. </returns>
        bool RemoveTag(Tag tag);
    }
}