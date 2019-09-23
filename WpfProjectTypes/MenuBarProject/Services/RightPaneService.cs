using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Contracts.ViewModels;

namespace MenuBarProject.Services
{
    public class RightPaneService : IRightPaneService
    {
        private Frame _frame;
        private IServiceProvider _serviceProvider;
        private INavigationService _navigationService;
        private object _lastParameterUsed;
        private Action _openRightPane;

        public RightPaneService(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public void Initialize(Frame rightPaneFrame, Action openRightPane)
        {
            _frame = rightPaneFrame;
            _openRightPane = openRightPane;
            _frame.Navigated += OnNavigated;
        }

        public void OpenInRightPane(string viewModelName, object parameter = null)
        {
            var pageType = _navigationService.GetPageType(viewModelName);
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                var page = _serviceProvider.GetService(pageType);
                if (_frame.Content is FrameworkElement element)
                {
                    if (element.DataContext is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatingFrom();
                    }
                }
                var navigated = _frame.Navigate(page, parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;
                }
            }

            _openRightPane();
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
    }
}
