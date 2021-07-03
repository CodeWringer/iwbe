using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Iwbe.Presentation
{
    /// <summary>
    /// Abstract base class of view models. 
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the event PropertyChanged, passing name of the currently invoking member. 
        /// </summary>
        /// <param name="name"></param>
        internal void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
