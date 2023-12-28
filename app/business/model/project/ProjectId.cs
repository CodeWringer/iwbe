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
        public ObservableData<string> Name = new();

        /// <summary>
        /// Full file path on disk. 
        /// </summary>
        public ObservableData<string> PathOnDisk = new();

        /// <summary>
        /// Date and time of creation. 
        /// </summary>
        public ObservableData<DateTime> CreationDate = new();

        /// <summary>
        /// Date and time of last edit/open of the project. 
        /// </summary>
        public ObservableData<DateTime> LastEditDate = new();

        /// <summary>
        /// If true, determines this project to be pinned. 
        /// </summary>
        public ObservableData<bool> IsPinned = new();

        public ProjectId()
        {
            ID = new Guid();

            Name.Changed += Changed;
            PathOnDisk.Changed += Changed;
            CreationDate.Changed += Changed;
            LastEditDate.Changed += Changed;
            IsPinned.Changed += Changed;
        }

        public ProjectId(string name, string pathOnDisk, Guid id, DateTime creationDate, DateTime lastEditDate)
        {
            ID = id;

            Name = new ObservableData<string>(name);
            Name.Changed += Changed;

            PathOnDisk = new ObservableData<string>(pathOnDisk);
            PathOnDisk.Changed += Changed;

            CreationDate = new ObservableData<DateTime>(creationDate);
            CreationDate.Changed += Changed;

            LastEditDate = new ObservableData<DateTime>(lastEditDate);
            LastEditDate.Changed += Changed;

            IsPinned.Changed += Changed;
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
                isPinned = IsPinned.Value,
            };
        }
    }
}