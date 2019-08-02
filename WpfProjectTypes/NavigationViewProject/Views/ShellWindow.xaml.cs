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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using NavigationViewProject.Services;
using NavigationViewProject.ViewModels;

namespace NavigationViewProject.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow(ShelWindowViewModel viewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
