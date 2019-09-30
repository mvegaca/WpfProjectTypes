using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using RibbonProject.Contracts.Services;
using RibbonProject.Contracts.ViewModels;
using RibbonProject.Contracts.Views;

namespace RibbonProject.Services
{
    public class WindowManagerService : IWindowManagerService
    {
        private IServiceProvider _serviceProvider;
        private INavigationService _navigationService;

        public WindowManagerService(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public void OpenInNewWindow(string viewModelName, object parameter = null)
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
            var navigated = frame.Navigate(page, parameter);
        }

        public bool? OpenInDialog(string viewModelName, object parameter = null)
        {
            var shellWindow = _serviceProvider.GetService(typeof(IShellDialogWindow)) as Window;
            var frame = ((IShellDialogWindow)shellWindow).GetDialogFrame();
            frame.Navigated += OnNavigated;
            shellWindow.Closed += OnWindowClosed;
            var pageType = _navigationService.GetPageType(viewModelName);
            var page = _serviceProvider.GetService(pageType);
            var navigated = frame.Navigate(page, parameter);
            return shellWindow.ShowDialog();
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is FrameworkElement element)
            {
                if (element.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            if (sender is Window window)
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
