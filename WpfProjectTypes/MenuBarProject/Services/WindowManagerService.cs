using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Contracts.ViewModels;
using MenuBarProject.Contracts.Views;
using MenuBarProject.Helpers;

namespace MenuBarProject.Services
{
    public class WindowManagerService : IWindowManagerService
    {
        private IServiceProvider _serviceProvider;
        private INavigationService _navigationService;

        private Dictionary<string, Window> SecondaryWindows { get; } = new Dictionary<string, Window>();

        public Window MainWindow
            => Application.Current.MainWindow;

        public WindowManagerService(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public void OpenInNewWindow(string viewModelName, object parameter = null)
        {
            var window = SecondaryWindows.GetValueOrDefault(viewModelName);
            if (window != null)
            {
                window.Activate();
            }
            else
            {
                window = new MetroWindow()
                {
                    Title = "MenuBarProject"
                };
                var frame = new Frame()
                {
                    Focusable = false,
                    NavigationUIVisibility = NavigationUIVisibility.Hidden
                };

                window.Content = frame;
                var pageType = _navigationService.GetPageType(viewModelName);
                var page = _serviceProvider.GetService(pageType);
                window.Closed += OnWindowClosed;
                SecondaryWindows.Add(viewModelName, window);
                window.Show();
                frame.Navigated += OnNavigated;
                var navigated = frame.Navigate(page, parameter);
            }
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

        public Window GetWindow(string viewModelName)
            => SecondaryWindows.GetValueOrDefault(viewModelName);

        public Observable GetViewModel(string viewModelName)
        {
            var window = SecondaryWindows.GetValueOrDefault(viewModelName);
            if (window != null)
            {
                if (window.Content is Frame frame)
                {
                    if (frame.Content is FrameworkElement frameworkElement)
                    {
                        return frameworkElement.DataContext as Observable;
                    }
                }
            }

            return null;
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
                    if (frame.Content is FrameworkElement frameworkElement)
                    {
                        var viewModelName = frameworkElement.DataContext.GetType().FullName;
                        SecondaryWindows.Remove(viewModelName);
                    }
                }

                window.Closed -= OnWindowClosed;
            }
        }
    }
}