using System;
using System.Windows.Controls;
using System.Windows.Input;
using RibbonProject.Contracts.Services;
using RibbonProject.Helpers;

namespace RibbonProject.ViewModels
{
    public class ShellWindowViewModel : Observable
    {
        private INavigationService _navigationService;
        private IWindowManagerService _windowManagerService;
        private IRightPaneService _rightPaneService;
        private ICommand _showInDialogCommand;
        private ICommand _openInANewWindowCommand;
        private ICommand _openInRightPaneCommand;
        private ICommand _navigateCommand;

        public ICommand ShowInDialogCommand => _showInDialogCommand ?? (_showInDialogCommand = new RelayCommand<string>(OnShowInDialog));

        public ICommand OpenInANewWindowCommand => _openInANewWindowCommand ?? (_openInANewWindowCommand = new RelayCommand<string>(OnOpenInANewWindow));

        public ICommand OpenInRightPaneCommand => _openInRightPaneCommand ?? (_openInRightPaneCommand = new RelayCommand<string>(OnOpenInRightPane));

        public ICommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new RelayCommand<string>(OnNavigate));

        public ShellWindowViewModel(INavigationService navigationService, IWindowManagerService windowManagerService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _windowManagerService = windowManagerService;
            _rightPaneService = rightPaneService;
        }

        private void OnShowInDialog(string viewModelName)
            =>_windowManagerService.OpenInDialog(viewModelName);

        private void OnOpenInANewWindow(string viewModelName)
            => _windowManagerService.OpenInNewWindow(viewModelName);

        private void OnOpenInRightPane(string viewModelName)
            => _rightPaneService.OpenInRightPane(viewModelName);

        private void OnNavigate(string viewModelName)
            => _navigationService.Navigate(viewModelName, null, true);
    }
}
