using System.Windows.Controls;
using BlankProject.Contracts.Views;
using BlankProject.ViewModels;
using MahApps.Metro.Controls;

namespace BlankProject.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();
    }
}
