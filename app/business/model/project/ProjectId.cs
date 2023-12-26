using iwbe.business.dataaccess.dto;
using iwbe.common.observables;
using System;

namespace iwbe.business.model
{
    /// <summary>
    /// Identifying information of a project. 
    /// </summary>
    public class ProjectId : IEquatable<ProjectId>, IObservableData, ISerializable<ProjectId, ProjectIdDto>
    {
        internal static ProjectId FromDto(ProjectIdDto id)
        {
            return new ProjectId(id.name, id.pathOnDisk, Guid.Parse(id.id), DateTime.Parse(id.creationDate), DateTime.Parse(id.lastEditDate));
        }

        public event IObservableData.ChangedHandler Changed;


        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public Guid ID;

        /// <summary>
        /// Display name of a project. 
        /// </summary>
        public ObservableData<string> Name;

        /// <summary>
        /// Full file path on disk. 
        /// </summary>
        public ObservableData<string> PathOnDisk;

        /// <summary>
        /// Date and time of creation. 
        /// </summary>
        public ObservableData<DateTime> CreationDate;

        /// <summary>
        /// Date and time of last edit/open of the project. 
        /// </summary>
        public ObservableData<DateTime> LastEditDate;

        public ProjectId()
        {
            Name = new ObservableData<string>();
            Name.Changed += Changed;

            PathOnDisk = new ObservableData<string>();
            PathOnDisk.Changed += Changed;

            ID = new Guid();

            CreationDate = new ObservableData<DateTime>();
            CreationDate.Changed += Changed;

            LastEditDate = new ObservableData<DateTime>();
            LastEditDate.Changed += Changed;
        }

        public ProjectId(string name, string pathOnDisk, Guid id, DateTime creationDate, DateTime lastEditDate)
        {
            Name = new ObservableData<string>(name);
            Name.Changed += Changed;

            PathOnDisk = new ObservableData<string>(pathOnDisk);
            PathOnDisk.Changed += Changed;

            ID = id;
            CreationDate = new ObservableData<DateTime>(creationDate);
            CreationDate.Changed += Changed;

            LastEditDate = new ObservableData<DateTime>(lastEditDate);
            LastEditDate.Changed += Changed;
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

        public ProjectIdDto ToDto()
        {
            return new ProjectIdDto()
            {
                id = ID.ToString(),
                name = Name.Value,
                pathOnDisk = PathOnDisk.Value,
                creationDate = CreationDate.Value.ToShortDateString(),
                lastEditDate = LastEditDate.Value.ToShortDateString(),
            };
        }
    }
}