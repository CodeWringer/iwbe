namespace Iwbe.Domain.Model
{
    public struct ProjectSort
    {
        public SortDirections direction;

        public ProjectSortProperties projectSortProperty;

        public ProjectSort(SortDirections direction, ProjectSortProperties property)
        {
            this.direction = direction;
            this.projectSortProperty = property;
        }
    }
}