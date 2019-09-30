using System;
using System.Windows.Controls;
using System.Windows.Input;
using RibbonProject.Contracts.Services;
using RibbonProject.Helpers;

namespace RibbonProject.ViewModels
{
    public class ShellWindowViewModel : Observable, IDisposable
    {
        private INavigationService _navigationService;
        private IWindowManagerService _windowManagerService;
        private IRightPaneService _rightPaneService;
        private RelayCommand _goBackCommand;
        private ICommand _showInDialogCommand;
        private ICommand _openInANewWindowCommand;
        private ICommand _openInRightPaneCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand ShowInDialogCommand => _showInDialogCommand ?? (_showInDialogCommand = new RelayCommand<string>(OnShowInDialog));

        public ICommand OpenInANewWindowCommand => _openInANewWindowCommand ?? (_openInANewWindowCommand = new RelayCommand<string>(OnOpenInANewWindow));

        public ICommand OpenInRightPaneCommand => _openInRightPaneCommand ?? (_openInRightPaneCommand = new RelayCommand<string>(OnOpenInRightPane));

        public ShellWindowViewModel(INavigationService navigationService, IWindowManagerService windowManagerService, IRightPaneService rightPaneService)
        {
            _navigationService = navigationService;
            _windowManagerService = windowManagerService;
            _rightPaneService = rightPaneService;
            _navigationService.Navigated += OnNavigated;
        }

        public void Dispose()
        {
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, string e)
        {
            GoBackCommand.OnCanExecuteChanged();
        }

        private void OnShowInDialog(string viewModelName)
            =>_windowManagerService.OpenInDialog(viewModelName);

        private void OnOpenInANewWindow(string viewModelName)
            => _windowManagerService.OpenInNewWindow(viewModelName);

        private void OnOpenInRightPane(string viewModelName)
            => _rightPaneService.OpenInRightPane(viewModelName);
    }
}
