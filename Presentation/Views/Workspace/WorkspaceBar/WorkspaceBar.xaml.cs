using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for WorkspaceBar.xaml
    /// </summary>
    public partial class WorkspaceBar : UserControl
    {
        private WorkspaceBarViewModel vm = new WorkspaceBarViewModel();

        public WorkspaceBar()
        {
            InitializeComponent();
            this.DataContext = vm;

            var bindingIsEnabled = new Binding("WorkspacesEnabled")
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.OneWay
            };
            btnWorkspaceProject.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
            btnWorkspaceWriting.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
            btnWorkspaceCanvas.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
            btnWorkspaceTimeline.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
            btnWorkspaceHierarchies.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
            btnWorkspaceSearch.SetBinding(Button.IsEnabledProperty, bindingIsEnabled);
        }

        private void btnWorkspaceWriting_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SetActiveWorkspace(WorkspaceTypes.Writing);
        }

        private void btnWorkspaceCanvas_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SetActiveWorkspace(WorkspaceTypes.Canvas);
        }

        private void btnWorkspaceTimeline_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SetActiveWorkspace(WorkspaceTypes.Timeline);
        }

        private void btnWorkspaceHierarchies_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SetActiveWorkspace(WorkspaceTypes.Hierarchies);
        }

        private void btnWorkspaceSearch_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SetActiveWorkspace(WorkspaceTypes.Search);
        }
    }
}