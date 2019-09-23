using System;
using System.Windows.Controls;

namespace MenuBarProject.Contracts.Services
{
    public interface INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        Type GetPageType(string viewModelName);

        bool Navigate(string viewModelName, object parameter = null, bool clearNavigation = false);

        void GoBack();
    }
}
