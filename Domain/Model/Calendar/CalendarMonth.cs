using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a month in a fictional calendar. 
    /// </summary>
    public class CalendarMonth
    {
        public Watchable<string> NameWatchable = new Watchable<string>();
        /// <summary>
        /// Name of the month. E. g. "January", "May", etc. 
        /// </summary>
        public string Name

        {
            get => NameWatchable.Value;
            set => NameWatchable.Value = value;
        }

        public Watchable<int> NumberOfDaysWatchable = new Watchable<int>();
        /// <summary>
        /// The number of days in this month. 
        /// </summary>
        public int NumberOfDays

        {
            get => NumberOfDaysWatchable.Value;
            set => NumberOfDaysWatchable.Value = value;
        }
    }
}