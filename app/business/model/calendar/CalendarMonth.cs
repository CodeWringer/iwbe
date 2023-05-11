namespace iwbe.business.model
{
    /// <summary>
    /// Represents a month in a fictional calendar. 
    /// </summary>
    public class CalendarMonth
    {
        /// <summary>
        /// Name of the month. E. g. "January", "May", etc. 
        /// </summary>
        public string Name;

        /// <summary>
        /// Abbreviated name. E. g. "Jan", "Flrb", etc.
        /// </summary>
        public string AbbreviatedName;

        /// <summary>
        /// The number of days in this month. 
        /// </summary>
        public int NumberOfDays;
    }
}