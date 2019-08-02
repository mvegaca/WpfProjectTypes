using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace MenuBarProject.Services
{
    public class NavigationService
    {
        private bool _isInitialized = false;
        private bool _isNavigated = false;
        private IServiceProvider _serviceProvider;
        private Frame _frame;
        private Frame _secondaryFrame;
        private SplitView _splitView;
        private object _lastExtraDataUsed;

        public event NavigatedEventHandler Navigated;

        public event NavigationFailedEventHandler NavigationFailed;

        public bool CanGoBack => _frame.CanGoBack;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Initialize(SplitView splitView)
        {
            if (!_isInitialized)
            {
                _splitView = splitView;
                _frame = _splitView.Content as Frame;
                _secondaryFrame = _splitView.Pane as Frame;
                _frame.Navigated += OnNavigated;
                _frame.NavigationFailed += OnNavigationFailed;
                _isInitialized = true;
            }
        }

        public bool IsNavigated()
            => _isNavigated;

        public bool Navigate<T>(object extraData = null, bool useSecondaryFrame = false)
            where T : Page
            => Navigate(typeof(T), extraData);

        public bool Navigate(Type pageType, object extraData = null, bool useSecondaryFrame = false)
        {
            if (_frame.Content?.GetType() != pageType || (extraData != null && !extraData.Equals(_lastExtraDataUsed)))
            {
                return Navigate(_serviceProvider.GetService(pageType), extraData, useSecondaryFrame);
            }

            return false;
        }

        public void GoBack()
            => _frame.GoBack();

        private bool Navigate(object content, object extraData, bool useSecondaryFrame = false)
        {
            var frame = useSecondaryFrame ? _secondaryFrame : _frame;
            var navigated = frame.Navigate(content, extraData);
            if (navigated)
            {
                if (useSecondaryFrame)
                {
                    _splitView.IsPaneOpen = true;
                }
                else
                {
                    _lastExtraDataUsed = extraData;
                    _isNavigated = true;
                }
            }

            return navigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
            => Navigated?.Invoke(this, e);

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
            => NavigationFailed?.Invoke(this, e);
    }
}