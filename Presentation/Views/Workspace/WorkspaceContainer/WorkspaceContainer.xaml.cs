using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iwbe.Presentation
{
    /// <summary>
    /// Interaction logic for WorkspaceContainer.xaml
    /// </summary>
    public partial class WorkspaceContainer : UserControl
    {
        public WorkspaceContainer()
        {
            InitializeComponent();

            WorkspaceContentArea.Content = new WorkspaceHome();

            ((App)App.Current).ViewState.ActiveWorkspace.PropertyChanged += ActiveWorkspace_PropertyChanged;
        }

        private void ActiveWorkspace_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
