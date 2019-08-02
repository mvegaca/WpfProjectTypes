using System.Windows;
using Fluent;
using MahApps.Metro.Controls;
using RibbonProject.Services;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : MetroWindow
    {
        private RibbonTitleBar _titleBar;

        public ShellWindow(ShelWindowViewModel viewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationService.Initialize(shellFrame);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _titleBar = this.FindChild<RibbonTitleBar>("RibbonTitleBar");
            _titleBar.InvalidateArrange();
            _titleBar.UpdateLayout();
        }
    }
}
