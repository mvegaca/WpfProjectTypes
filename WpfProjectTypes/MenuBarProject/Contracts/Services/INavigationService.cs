using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MenuBarProject.Models;

namespace MenuBarProject.Contracts.Services
{
    public interface INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        Type GetPageType(string viewModelName);

        bool Navigate(string viewModelName, object extraData = null, bool clearNavigation = false);

        void GoBack();
    }
}
