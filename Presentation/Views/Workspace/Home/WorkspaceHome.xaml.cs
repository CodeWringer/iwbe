﻿using System;
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
    /// Interaction logic for WorkspaceHome.xaml
    /// </summary>
    public partial class WorkspaceHome : UserControl
    {
        public WorkspaceHome()
        {
            InitializeComponent();

            PinnedProjects.TestProperty = "";
        }
    }
}
