using System.Windows.Controls;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
