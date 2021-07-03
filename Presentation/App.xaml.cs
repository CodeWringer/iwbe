using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Iwbe.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewState ViewState { get; private set; }

        public App()
        {
            this.ViewState = new ViewState(null, "ViewState");
        }
    }
}
