using System;
using System.Windows;
using System.Windows.Input;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class ShellWindowViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private readonly IRightPaneService _rightPaneService;
        private readonly IWindowManagerService _windowManagerService;

        private RelayCommand _goBackCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuViewsBlank1Command;
        private ICommand _menuViewsBlank2Command;
        private ICommand _menuViewsBlank3Command;
        private ICommand _menuViewsBlank4Command;
        private ICommand _menuFilesSettingsCommand;
        private ICommand _menuFileExitCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public ICommand MenuViewsBlank1Command => _menuViewsBlank1Command ?? (_menuViewsBlank1Command = new RelayCommand(OnMenuViewsBlank1));

        public ICommand MenuViewsBlank2Command => _menuViewsBlank2Command ?? (_menuViewsBlank2Command = new RelayCommand(OnMenuViewsBlank2));

        public ICommand MenuViewsBlank3Command => _menuViewsBlank3Command ?? (_menuViewsBlank3Command = new RelayCommand(OnMenuViewsBlank3));

        public ICommand MenuViewsBlank4Command => _menuViewsBlank4Command ?? (_menuViewsBlank4Command = new RelayCommand(OnMenuViewsBlank4));

        public ICommand MenuFileSettingsCommand => _menuFilesSettingsCommand ?? (_menuFilesSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ShellWindowViewModel(INavigationService navigationService, IWindowManagerService windowManagerService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _rightPaneService = rightPaneService;
            _windowManagerService = windowManagerService;
            _navigationService.Navigated += OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnMenuViewsMain()
            => _navigationService.Navigate(typeof(MainViewModel).FullName, null);

        private void OnMenuViewsBlank1()
            => _navigationService.Navigate(typeof(Blank1ViewModel).FullName, null);

        private void OnMenuViewsBlank2()
            => _navigationService.Navigate(typeof(Blank2ViewModel).FullName, null, true);

        private void OnMenuViewsBlank3()
            => _windowManagerService.OpenInNewWindow(typeof(Blank3ViewModel).FullName);

        private void OnMenuViewsBlank4()
            => _windowManagerService.OpenInDialog(typeof(Blank4ViewModel).FullName);

        private void OnMenuFileSettings()
            => _rightPaneService.OpenInRightPane(typeof(SettingsViewModel).FullName);

        private void OnMenuFileExit()
            => Application.Current.Shutdown();

        private void OnNavigated(object sender, string e)
            => GoBackCommand.OnCanExecuteChanged();
    }
}
