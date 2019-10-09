using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RibbonProject.Contracts.Services;
using RibbonProject.Contracts.Views;
using RibbonProject.ViewModels;

namespace RibbonProject.Services
{
    internal class ApplicationHostService : IHostedService
    {
        private INavigationService _navigationService;
        private IThemeSelectorService _themeSelectorService;
        private IPersistAndRestoreService _persistAndRestoreService;
        private IShellWindow _shellWindow;

        public ApplicationHostService(IThemeSelectorService themeSelectorService, IPersistAndRestoreService persistAndRestoreService, INavigationService navigationService, IRightPaneService rightPaneService, IShellWindow shellWindow)
        {
            _themeSelectorService = themeSelectorService;
            _persistAndRestoreService = persistAndRestoreService;
            _shellWindow = shellWindow;
            _navigationService = navigationService;
            _navigationService.Initialize(_shellWindow.GetNavigationFrame());
            var behavior = _shellWindow.GetRibbonTabsBehavior();
            behavior.Initialize(_navigationService);
            rightPaneService.Initialize(_shellWindow.GetRightPaneFrame(), _shellWindow.GetSplitView());
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            _shellWindow.ShowWindow();
            _navigationService.Navigate(typeof(MainViewModel).FullName);

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            _persistAndRestoreService.PersistData();
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
            _persistAndRestoreService.RestoreData();
            _themeSelectorService.SetTheme();
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }
    }
}
