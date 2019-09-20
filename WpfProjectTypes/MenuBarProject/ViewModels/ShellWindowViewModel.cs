using System.Windows;
using System.Windows.Input;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class ShellWindowViewModel : Observable
    {
        private IMenuNavigationService _menuNavigationService;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuViewsBlankCommand;
        private ICommand _menuFilesSettingsCommand;
        private ICommand _menuViewsNewWindowMainCommand;
        private ICommand _menuFileExitCommand;

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public ICommand MenuViewsBlankCommand => _menuViewsBlankCommand ?? (_menuViewsBlankCommand = new RelayCommand(OnMenuViewsBlank));

        public ICommand MenuViewsNewWindowMainCommand => _menuViewsNewWindowMainCommand ?? (_menuViewsNewWindowMainCommand = new RelayCommand(OnMenuViewsNewWindowMain));

        public ICommand MenuFileSettingsCommand => _menuFilesSettingsCommand ?? (_menuFilesSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ShellWindowViewModel(IMenuNavigationService menuNavigationService)
        {
            _menuNavigationService = menuNavigationService;
        }

        private void OnMenuViewsMain()
            => _menuNavigationService.UpdateView(typeof(MainViewModel).FullName);

        private void OnMenuViewsBlank()
        => _menuNavigationService.UpdateView(typeof(BlankViewModel).FullName);

        private void OnMenuViewsNewWindowMain()
        => _menuNavigationService.OpenInNewWindow(typeof(MainViewModel).FullName);

        private void OnMenuFileSettings()
        => _menuNavigationService.OpenInRightPane(typeof(SettingsViewModel).FullName);

        private void OnMenuFileExit()
            => Application.Current.Shutdown();
    }
}
