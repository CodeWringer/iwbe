using StoreSystem;
using System;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Identifying information of a project. 
    /// </summary>
    public class ProjectId : IEquatable<ProjectId>
    {
        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public Guid Id { get; private set; }

        public Watchable<string> NameWatchable { get; private set; } = new Watchable<string>();
        /// <summary>
        /// Display name of a project. 
        /// </summary>
        public string Name
        {
            get => NameWatchable.Value;
            set => NameWatchable.Value = value;
        }

        public Watchable<string> PathOnDiskWatchable { get; private set; } = new Watchable<string>();
        /// <summary>
        /// Full file path on disk. 
        /// </summary>
        public string PathOnDisk
        {
            get => PathOnDiskWatchable.Value;
            set => PathOnDiskWatchable.Value = value;
        }

        public Watchable<DateTime> CreationDateWatchable { get; private set; } = new Watchable<DateTime>();
        /// <summary>
        /// Date and time of creation. 
        /// </summary>
        public DateTime CreationDate
        {
            get => CreationDateWatchable.Value;
            set => CreationDateWatchable.Value = value;
        }

        public Watchable<DateTime> LastEditDateWatchable { get; private set; } = new Watchable<DateTime>();
        /// <summary>
        /// Date and time of last edit/open of the project. 
        /// </summary>
        public DateTime LastEditDate
        {
            get => LastEditDateWatchable.Value;
            set => LastEditDateWatchable.Value = value;
        }

        public ProjectId(Guid id, string name, string pathOnDisk, DateTime creationDate, DateTime lastEditDate)
        {
            this.Id = id;
            this.Name = name;
            this.PathOnDisk = pathOnDisk;
            this.CreationDate = creationDate;
            this.LastEditDate = lastEditDate;
        }

        public ProjectId(Guid id)
            : this(id, "", "", DateTime.Now, DateTime.Now)
        {
        }

        public bool Equals(ProjectId other)
        {
            return other.Id == Id;
        }
    }
}