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
    public partial class ShellWindow : MetroWindow, IShellWindow, IRibbonWindow
    {
        public ShellWindow(ShellWindowViewModel viewModel, IPageService pageService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationBehavior.Initialize(pageService);
        }

        /// <summary>
        /// Gets ribbon titlebar.
        /// </summary>
        public RibbonTitleBar TitleBar
        {
            get => (RibbonTitleBar)GetValue(TitleBarProperty);
            private set => SetValue(TitleBarPropertyKey, value);
        }

        // ReSharper disable once InconsistentNaming
        private static readonly DependencyPropertyKey TitleBarPropertyKey = DependencyProperty.RegisterReadOnly(nameof(TitleBar), typeof(RibbonTitleBar), typeof(ShellWindow), new PropertyMetadata());

        /// <summary>
        /// <see cref="DependencyProperty"/> for <see cref="TitleBar"/>.
        /// </summary>
        public static readonly DependencyProperty TitleBarProperty = TitleBarPropertyKey.DependencyProperty;

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
            TitleBar = this.FindChild<RibbonTitleBar>("RibbonTitleBar");
            TitleBar.InvalidateArrange();
            TitleBar.UpdateLayout();
        }
    }
}
