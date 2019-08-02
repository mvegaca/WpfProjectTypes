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
using NavigationViewProject.ViewModels;

namespace NavigationViewProject.Views
{
    /// <summary>
    /// Interaction logic for SecondaryPage.xaml
    /// </summary>
    public partial class SecondaryPage : Page
    {
        public SecondaryPage(SecondaryViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
