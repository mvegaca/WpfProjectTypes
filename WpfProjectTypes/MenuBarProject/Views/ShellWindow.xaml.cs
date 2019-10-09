using System.Windows.Controls;
using MahApps.Metro.Controls;
using MenuBarProject.Contracts.Views;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml.
    /// </summary>
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public Frame GetRightPaneFrame()
            => rightPaneFrame;

        public void ShowWindow()
            => Show();

        public SplitView GetSplitView()
            => splitView;
    }
}
