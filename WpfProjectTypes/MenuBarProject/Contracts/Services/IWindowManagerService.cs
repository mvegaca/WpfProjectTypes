using System.Windows;
using MenuBarProject.Helpers;

namespace MenuBarProject.Contracts.Services
{
    public interface IWindowManagerService
    {
        Window MainWindow { get; }

        void OpenInNewWindow(string viewModelName, object parameter = null);

        bool? OpenInDialog(string viewModelName, object parameter = null);

        Window GetWindow(string viewModelName);

        Observable GetViewModel(string viewModelName);
    }
}
