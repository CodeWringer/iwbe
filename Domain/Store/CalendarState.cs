using Iwbe.Domain.Model;
using StoreSystem;

namespace Iwbe.Domain.StoreSystem
{
    public class CalendarState
    {
        public WatchableCollection<Calendar> CalendarsWatchable { get; private set; } = new WatchableCollection<Calendar>();
        public ObservableList<Calendar> Calendars
        {
            get => CalendarsWatchable.Collection;
            set => CalendarsWatchable.Collection = value;
        }

        public CalendarState()
        {
        }
    }
}