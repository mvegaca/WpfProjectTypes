using MenuBarProject.Contracts.Views;

namespace MenuBarProject.Contracts.Services
{
    public interface IMenuNavigationService
    {
        void Initialize(IShellWindow shellWindow);

        void UpdateView(string viewModelName, object extraData = null);

        void Navigate(string viewModelName, object extraData = null);

        void OpenInRightPane(string viewModelName, object extraData = null);

        void OpenInNewWindow(string viewModelName, object extraData = null);

        void OpenInDialog(string viewModelName, object extraData = null);
    }
}
