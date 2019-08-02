using System;
using System.Windows;
using System.Windows.Input;
using MenuBarProject.Helpers;
using MenuBarProject.Services;

namespace MenuBarProject.ViewModels
{
    public class ShelWindowViewModel : Observable
    {
        private NavigationService _navigationService;
        private ICommand _mainFrameNavigateCommand;
        private ICommand _secondaryFrameNavigateCommand;
        private ICommand _exitCommand;

        public ICommand MainFrameNavigateCommand => _mainFrameNavigateCommand ?? (_mainFrameNavigateCommand = new RelayCommand<string>(OnMainFrameNavigate));

        public ICommand SecondaryFrameNavigateCommand => _secondaryFrameNavigateCommand ?? (_secondaryFrameNavigateCommand = new RelayCommand<string>(OnSecondaryFrameNavigate));

        public ICommand ExitCommand => _exitCommand ?? (_exitCommand = new RelayCommand(OnExit));

        public ShelWindowViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void OnMainFrameNavigate(string typeName)
            => _navigationService.Navigate(Type.GetType(typeName));

        private void OnSecondaryFrameNavigate(string typeName)
            => _navigationService.Navigate(Type.GetType(typeName), null, true);

        private void OnExit()
            => Application.Current.Shutdown();
    }
}
