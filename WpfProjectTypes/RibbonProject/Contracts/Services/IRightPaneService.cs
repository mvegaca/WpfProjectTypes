using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace RibbonProject.Contracts.Services
{
    public interface IRightPaneService
    {
        void OpenInRightPane(string pageKey, object parameter = null);

        void Initialize(Frame rightPaneFrame, SplitView splitView);
    }
}
