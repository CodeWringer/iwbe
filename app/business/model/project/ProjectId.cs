using System;

namespace iwbe.business.model
{
    /// <summary>
    /// Identifying information of a project. 
    /// </summary>
    public class ProjectId : IEquatable<ProjectId>
    {
        /// <summary>
        /// Display name of a project. 
        /// </summary>
        public string Name;

        /// <summary>
        /// Full file path on disk. 
        /// </summary>
        public string PathOnDisk;

        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public Guid ID;

        /// <summary>
        /// Date and time of creation. 
        /// </summary>
        public DateTime CreationDate;

        /// <summary>
        /// Date and time of last edit/open of the project. 
        /// </summary>
        public DateTime LastEditDate;

        public bool Equals(ProjectId other)
        {
            return other.ID == ID;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectId);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}