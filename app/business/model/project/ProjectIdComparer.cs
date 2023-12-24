using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Allows comparing and sorting projects, based on their metadata. 
    /// </summary>
    public sealed class ProjectIdComparer : IComparer<ProjectId>
    {
        private SortDirections _direction;
        private ProjectSortProperties _property;

        public ProjectIdComparer(ProjectSortProperties property, SortDirections direction = SortDirections.Ascending)
        {
            _direction = direction;
            _property = property;
        }

        public int Compare(ProjectId x, ProjectId y)
        {
            if (_property == ProjectSortProperties.CreationDate)
            {
                if (_direction == SortDirections.Ascending)
                    return x.CreationDate.Value.CompareTo(y.CreationDate);
                else
                    return y.CreationDate.Value.CompareTo(x.CreationDate);
            }
            else if (_property == ProjectSortProperties.LastEditDate)
            {
                if (_direction == SortDirections.Ascending)
                    return x.LastEditDate.Value.CompareTo(y.LastEditDate);
                else
                    return y.LastEditDate.Value.CompareTo(x.LastEditDate);
            }
            else if (_property == ProjectSortProperties.Path)
            {
                if (_direction == SortDirections.Ascending)
                    return x.PathOnDisk.Value.CompareTo(y.PathOnDisk);
                else
                    return y.PathOnDisk.Value.CompareTo(x.PathOnDisk);
            }
            else
            {
                if (_direction == SortDirections.Ascending)
                    return x.Name.Value.CompareTo(y.Name);
                else
                    return y.Name.Value.CompareTo(x.Name);
            }
        }
    }
}