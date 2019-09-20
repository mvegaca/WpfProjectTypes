using System;
using System.Windows.Controls;

namespace BlankProject.Contracts.Services
{
    public interface INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        bool Navigate(string pageKey, object extraData = null);

        void GoBack();

    }
}
