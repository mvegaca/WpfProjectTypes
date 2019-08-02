using MahApps.Metro.Controls;
using MenuBarProject.Services;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
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
            navigationService.Initialize(splitView);
        }
    }
}
