using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class MainViewModel : Observable
    {
        private IMenuNavigationService _menuNavigationService;
        private INavigationService _navigationService;

        public MainViewModel(IMenuNavigationService menuNavigationService, INavigationService navigationService)
        {
            _menuNavigationService = menuNavigationService;
        }

        private void OnCLick()
        {
            // Harían lo mismo
            _menuNavigationService.UpdateView(typeof(BlankViewModel).FullName, "Param 1");
            _navigationService.Navigate(typeof(BlankViewModel).FullName, "Param 1", true);
        }
    }
}
