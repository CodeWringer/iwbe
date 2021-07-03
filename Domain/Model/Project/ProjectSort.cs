namespace Iwbe.Domain.Model
{
    public struct ProjectSort
    {
        public SortDirections Direction;

        public ProjectSortProperties ProjectSortProperty;

        public ProjectSort(SortDirections direction, ProjectSortProperties property)
        {
            this.Direction = direction;
            this.ProjectSortProperty = property;
        }
    }
}