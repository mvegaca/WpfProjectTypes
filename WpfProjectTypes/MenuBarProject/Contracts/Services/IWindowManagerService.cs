namespace MenuBarProject.Contracts.Services
{
    public interface IWindowManagerService
    {
        void OpenInNewWindow(string viewModelName, object parameter = null);

        bool? OpenInDialog(string viewModelName, object parameter = null);
    }
}
