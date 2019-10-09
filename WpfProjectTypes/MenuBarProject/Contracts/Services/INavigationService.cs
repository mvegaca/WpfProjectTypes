using System;
using System.Windows.Controls;
using MenuBarProject.Helpers;

namespace MenuBarProject.Contracts.Services
{
    public interface INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        Observable CurrentViewModel { get; }

        bool Navigate(string viewModelName, object parameter = null, bool clearNavigation = false);

        void GoBack();
    }
}
