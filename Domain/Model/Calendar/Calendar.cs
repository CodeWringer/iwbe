using System;
using System.Collections.Generic;
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

        /// <summary>
        /// An arbitrary full name. E.g. "Universal Central Standard Time" or "Florb Time"
        /// </summary>
        public string Name;

        /// <summary>
        /// Abbreviated name. E. g. "UTC", "GMT", "FLORB", etc.
        /// </summary>
        public string ShorthandName;

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
            this.Weekdays = new List<string>();
            this.Months = new List<CalendarMonth>();

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