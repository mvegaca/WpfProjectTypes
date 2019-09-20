using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Contracts.ViewModels;
using MenuBarProject.Contracts.Views;

namespace MenuBarProject.Services
{
    public class MenuNavigationService : IMenuNavigationService
    {
        private object _lastExtraDataUsed;
        private INavigationService _navigationService;
        private IServiceProvider _serviceProvider;
        private IShellWindow _shellWindow;

        public MenuNavigationService(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public void Initialize(IShellWindow shellWindow)
            => _shellWindow = shellWindow;

        public void UpdateView(string viewModelName, object extraData = null)
            => _navigationService.Navigate(viewModelName, extraData, true);

        public void Navigate(string viewModelName, object extraData = null)
            => _navigationService.Navigate(viewModelName, extraData);

        public void OpenInRightPane(string viewModelName, object extraData = null)
        {
            var pageType = _navigationService.GetPageType(viewModelName);
            var frame = _shellWindow.GetRightPaneFrame();
            if (frame.Content?.GetType() != pageType || (extraData != null && !extraData.Equals(_lastExtraDataUsed)))
            {
                var page = _serviceProvider.GetService(pageType);
                if (frame.Content is FrameworkElement element)
                {
                    if (element.DataContext is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatingFrom();
                    }
                }
                var navigated = frame.Navigate(page, extraData);
                if (navigated)
                {
                    _lastExtraDataUsed = extraData;
                }
            }
            _shellWindow.OpenRightPane();
        }

        public void OpenInNewWindow(string viewModelName, object extraData = null)
        {
            var window = new MetroWindow()
            {
                Title = "MenuBarProject"
            };
            var frame = new Frame()
            {
                Focusable = false,
                NavigationUIVisibility = NavigationUIVisibility.Hidden
            };
            frame.Navigated += OnNavigated;
            window.Closed += OnWindowClosed;
            window.Content = frame;            
            var pageType = _navigationService.GetPageType(viewModelName);
            var page = _serviceProvider.GetService(pageType);
            window.Show();
            var navigated = frame.Navigate(page, extraData);
        }

        public void OpenInDialog(string viewModelName, object extraData = null)
        {
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(e.ExtraData);
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            if (sender is MetroWindow window)
            {
                if (window.Content is Frame frame)
                {
                    frame.Navigated -= OnNavigated;
                }

                window.Closed -= OnWindowClosed;
            }
        }
    }
}
