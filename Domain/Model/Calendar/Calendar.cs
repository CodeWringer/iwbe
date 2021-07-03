using StoreSystem;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a fictional calendar definition. 
    /// TODO: Leap-years and other time-nonsense related to calendar inaccuracies?
    /// </summary>
    public class Calendar : IEquatable<Calendar>
    {
        public Guid Id { get; private set; }

        public Watchable<string> NameWatchable = new Watchable<string>();
        /// <summary>
        /// An arbitrary full name. E.g. "Universal Central Standard Time" or "Florb Time"
        /// </summary>
        public string Name
        {
            get => NameWatchable.Value;
            set => NameWatchable.Value = value;
        }

        public Watchable<string> ShorthandNameWatchable = new Watchable<string>();
        /// <summary>
        /// Abbreviated name. E. g. "UTC", "GMT", "FLORB", etc.
        /// </summary>
        public string ShorthandName
        {
            get => ShorthandNameWatchable.Value;
            set => ShorthandNameWatchable.Value = value;
        }

        public WatchableCollection<string> WeekdaysWatchable = new WatchableCollection<string>();
        /// <summary>
        /// Definition of week days, in order of start to end of week. 
        /// E. g. "Sunday", "Monday", "Tuesday", etc. 
        /// </summary>
        public ObservableList<string> Weekdays
        {
            get => WeekdaysWatchable.Collection;
            set => WeekdaysWatchable.Collection = value;
        }

        public WatchableCollection<CalendarMonth> MonthsWatchable = new WatchableCollection<CalendarMonth>();
        /// <summary>
        /// List of months in a year. 
        /// </summary>
        public ObservableList<CalendarMonth> Months
        {
            get => MonthsWatchable.Collection;
            set => MonthsWatchable.Collection = value;
        }

        public Watchable<int> SecondsPerMinuteWatchable = new Watchable<int>();
        /// <summary>
        /// The number of seconds a single minute takes. 
        /// </summary>
        public int SecondsPerMinute
        {
            get => SecondsPerMinuteWatchable.Value;
            set => SecondsPerMinuteWatchable.Value = value;
        }

        public Watchable<int> MinutesPerHourWatchable = new Watchable<int>();
        /// <summary>
        /// The number of minutes a single hour takes. 
        /// </summary>
        public int MinutesPerHour
        {
            get => MinutesPerHourWatchable.Value;
            set => MinutesPerHourWatchable.Value = value;
        }

        public Watchable<int> HoursPerDayWatchable = new Watchable<int>();
        /// <summary>
        /// The number of hours a single day takes. 
        /// </summary>
        public int HoursPerDay
        {
            get => HoursPerDayWatchable.Value;
            set => HoursPerDayWatchable.Value = value;
        }

        public Calendar(Guid id)
        {
            this.Id = id;
        }

        public bool Equals([AllowNull] Calendar other)
        {
            if (other == null)
                return false;
            else
                return this.Id == other.Id;
        }
    }
}