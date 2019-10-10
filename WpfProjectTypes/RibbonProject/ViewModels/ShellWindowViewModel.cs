using System;
using System.Windows.Controls;
using System.Windows.Input;
using RibbonProject.Contracts.Services;
using RibbonProject.Helpers;

namespace RibbonProject.ViewModels
{
    public class ShellWindowViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private readonly IWindowManagerService _windowManagerService;
        private readonly IRightPaneService _rightPaneService;
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

        private void OnShowInDialog(string pageKey)
            => _windowManagerService.OpenInDialog(pageKey);

        private void OnOpenInANewWindow(string pageKey)
            => _windowManagerService.OpenInNewWindow(pageKey);

        private void OnOpenInRightPane(string pageKey)
            => _rightPaneService.OpenInRightPane(pageKey);

        private void OnNavigate(string pageKey)
            => _navigationService.Navigate(pageKey, null, true);
    }
}
