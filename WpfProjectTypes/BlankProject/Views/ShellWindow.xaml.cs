using BlankProject.Services;
using BlankProject.ViewModels;
using MahApps.Metro.Controls;

namespace BlankProject.Views
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
