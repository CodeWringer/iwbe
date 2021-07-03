using System.Collections.Generic;

namespace Iwbe.Domain.Model
{
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
                    return x.CreationDate.CompareTo(y.CreationDate);
                else
                    return y.CreationDate.CompareTo(x.CreationDate);
            }
            else if (_property == ProjectSortProperties.LastEditDate)
            {
                if (_direction == SortDirections.Ascending)
                    return x.LastEditDate.CompareTo(y.LastEditDate);
                else
                    return y.LastEditDate.CompareTo(x.LastEditDate);
            }
            else if (_property == ProjectSortProperties.Path)
            {
                if (_direction == SortDirections.Ascending)
                    return x.PathOnDisk.CompareTo(y.PathOnDisk);
                else
                    return y.PathOnDisk.CompareTo(x.PathOnDisk);
            }
            else
            {
                if (_direction == SortDirections.Ascending)
                    return x.Name.CompareTo(y.Name);
                else
                    return y.Name.CompareTo(x.Name);
            }
        }
    }
}