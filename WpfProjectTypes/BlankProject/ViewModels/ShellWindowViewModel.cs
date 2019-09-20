using System;
using BlankProject.Contracts.Services;
using BlankProject.Helpers;

namespace BlankProject.ViewModels
{
    public class ShellWindowViewModel : Observable, IDisposable
    {
        private INavigationService _navigationService;
        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ShellWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigated += OnNavigated;
        }

        public void Dispose()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, string viewModelName)
        {
            GoBackCommand.OnCanExecuteChanged();
        }
    }
}
