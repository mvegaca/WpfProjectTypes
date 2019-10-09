using System.Windows;

namespace RibbonProject.Contracts.Services
{
    public interface IWindowManagerService
    {
        Window MainWindow { get; }

        void OpenInNewWindow(string viewModelName, object parameter = null);

        bool? OpenInDialog(string viewModelName, object parameter = null);

        Window GetWindow(string viewModelName);
    }
}
