using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MenuBarProject.Contracts.Services
{
    public interface IRightPaneService
    {
        void OpenInRightPane(string viewModelName, object parameter = null);

        void Initialize(Frame rightPaneFrame, SplitView splitView);
    }
}
