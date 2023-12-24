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
        public Guid ID;

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
            Name.OnChanged += OnChanged;

            PathOnDisk = new ObservableField<string>();
            PathOnDisk.OnChanged += OnChanged;

            ID = new Guid();

            CreationDate = new ObservableField<DateTime>();
            CreationDate.OnChanged += OnChanged;

            LastEditDate = new ObservableField<DateTime>();
            LastEditDate.OnChanged += OnChanged;
        }

        public ProjectId(string name, string pathOnDisk, Guid id, DateTime creationDate, DateTime lastEditDate)
        {
            Name = new ObservableField<string>(name);
            Name.OnChanged += OnChanged;

            PathOnDisk = new ObservableField<string>(pathOnDisk);
            PathOnDisk.OnChanged += OnChanged;

            ID = id;
            CreationDate = new ObservableField<DateTime>(creationDate);
            CreationDate.OnChanged += OnChanged;

            LastEditDate = new ObservableField<DateTime>(lastEditDate);
            LastEditDate.OnChanged += OnChanged;
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