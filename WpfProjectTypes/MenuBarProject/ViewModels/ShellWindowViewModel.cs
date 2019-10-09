using System.Windows;
using System.Windows.Input;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class ShellWindowViewModel : Observable
    {
        private INavigationService _navigationService;
        private IRightPaneService _rightPaneService;
        private IWindowManagerService _windowManagerService;

        private ICommand _menuViewsMainCommand;
        private ICommand _menuViewsBlank1Command;
        private ICommand _menuViewsBlank2Command;
        private ICommand _menuViewsBlank3Command;
        private ICommand _menuFilesSettingsCommand;
        private ICommand _menuFileExitCommand;

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public ICommand MenuViewsBlank1Command => _menuViewsBlank1Command ?? (_menuViewsBlank1Command = new RelayCommand(OnMenuViewsBlank1));

        public ICommand MenuViewsBlank2Command => _menuViewsBlank2Command ?? (_menuViewsBlank2Command = new RelayCommand(OnMenuViewsBlank2));

        public ICommand MenuViewsBlank3Command => _menuViewsBlank3Command ?? (_menuViewsBlank3Command = new RelayCommand(OnMenuViewsBlank3));

        public ICommand MenuFileSettingsCommand => _menuFilesSettingsCommand ?? (_menuFilesSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ShellWindowViewModel(INavigationService navigationService, IWindowManagerService windowManagerService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _rightPaneService = rightPaneService;
            _windowManagerService = windowManagerService;
        }

        private void OnMenuViewsMain()
            => _navigationService.Navigate(typeof(MainViewModel).FullName, null, true);

        private void OnMenuViewsBlank1()
            => _navigationService.Navigate(typeof(Blank1ViewModel).FullName, null, true);

        private void OnMenuViewsBlank2()
            => _windowManagerService.OpenInNewWindow(typeof(Blank2ViewModel).FullName);

        private void OnMenuViewsBlank3()
            => _windowManagerService.OpenInDialog(typeof(Blank3ViewModel).FullName);

        private void OnMenuFileSettings()
            => _rightPaneService.OpenInRightPane(typeof(SettingsViewModel).FullName);

        private void OnMenuFileExit()
            => Application.Current.Shutdown();
    }
}
