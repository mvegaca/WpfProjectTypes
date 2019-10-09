using System;
using System.Windows;
using System.Windows.Controls;
using Fluent;
using MahApps.Metro.Controls;
using RibbonProject.Behaviors;
using RibbonProject.Contracts.Services;
using RibbonProject.Contracts.Views;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml.
    /// </summary>
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        private RibbonTitleBar _titleBar;

        public ShellWindow(ShellWindowViewModel viewModel, IPageService pageService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationBehavior.Initialize(pageService);
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public RibbonTabsBehavior GetRibbonTabsBehavior()
            => tabsBehavior;

        public Frame GetRightPaneFrame()
            => rightPaneFrame;

        public SplitView GetSplitView()
            => splitView;

        public void ShowWindow()
            => Show();

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _titleBar = this.FindChild<RibbonTitleBar>("RibbonTitleBar");
            _titleBar.InvalidateArrange();
            _titleBar.UpdateLayout();
        }
    }
}
