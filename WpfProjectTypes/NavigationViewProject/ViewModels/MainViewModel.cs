using System.Windows.Input;
using NavigationViewProject.Helpers;
using NavigationViewProject.Services;
using NavigationViewProject.Views;

namespace NavigationViewProject.ViewModels
{
    public class MainViewModel : Observable
    {
        private NavigationService _navigationService;
        private ICommand _navigateCommand;

        public ICommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new RelayCommand(OnNavigate));

        public MainViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void OnNavigate()
        {
            _navigationService.Navigate<SecondaryPage>("Hello world!");
        }
    }
}
