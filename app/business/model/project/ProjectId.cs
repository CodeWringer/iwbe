using iwbe.common.observables;
using System;

namespace iwbe.business.model
{
    /// <summary>
    /// Identifying information of a project. 
    /// </summary>
    public class ProjectId : IEquatable<ProjectId>, IObservableData
    {
        public event IObservableData.onChangedHandler OnChanged;

        /// <summary>
        /// Display name of a project. 
        /// </summary>
        public ObservableField<string> Name;

        /// <summary>
        /// Full file path on disk. 
        /// </summary>
        public ObservableField<string> PathOnDisk;

        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public ObservableField<Guid> ID;

        /// <summary>
        /// Date and time of creation. 
        /// </summary>
        public ObservableField<DateTime> CreationDate;

        /// <summary>
        /// Date and time of last edit/open of the project. 
        /// </summary>
        public ObservableField<DateTime> LastEditDate;

        public ProjectId()
        {
            Name = new ObservableField<string>();
            PathOnDisk = new ObservableField<string>();
            ID = new ObservableField<Guid>();
            CreationDate = new ObservableField<DateTime>();
            LastEditDate = new ObservableField<DateTime>();
        }

        public ProjectId(string name, string pathOnDisk, Guid id, DateTime creationDate, DateTime lastEditDate)
        {
            Name = new ObservableField<string>(name);
            PathOnDisk = new ObservableField<string>(pathOnDisk);
            ID = new ObservableField<Guid>(id);
            CreationDate = new ObservableField<DateTime>(creationDate);
            LastEditDate = new ObservableField<DateTime>(lastEditDate);
        }

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
            return ID.GetHashCode();
        }
    }
}