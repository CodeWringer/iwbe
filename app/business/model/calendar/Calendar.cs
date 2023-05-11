using System;
using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents a calendar definition. 
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// Unique ID of this calendar. 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// An arbitrary full name. E.g. "Universal Central Standard Time" or "Florb Time"
        /// </summary>
        public string Name;

        /// <summary>
        /// Abbreviated name. E. g. "UTC", "GMT", "FLORB", etc.
        /// </summary>
        public string AbbreviatedName;

        /// <summary>
        /// Definition of week days, in order of start to end of week. 
        /// E. g. "Sunday", "Monday", "Tuesday", etc. 
        /// </summary>
        public List<string> Weekdays;

        /// <summary>
        /// List of months in a year. 
        /// </summary>
        public List<CalendarMonth> Months;

        /// <summary>
        /// The number of seconds a single minute takes. 
        /// </summary>
        public int SecondsPerMinute;

        /// <summary>
        /// The number of minutes a single hour takes. 
        /// </summary>
        public int MinutesPerHour;

        /// <summary>
        /// The number of hours a single day takes. 
        /// </summary>
        public int HoursPerDay;

        public Calendar(Guid id)
        {
            Id = id;
        }
    }
}