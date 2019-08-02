using System;
using BlankProject.Helpers;
using BlankProject.Services;

namespace BlankProject.ViewModels
{
    public class ShelWindowViewModel : Observable, IDisposable
    {
        private NavigationService _navigationService;
        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ShelWindowViewModel(NavigationService navigationService)
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

        private void OnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
            => GoBackCommand.OnCanExecuteChanged();
    }
}
