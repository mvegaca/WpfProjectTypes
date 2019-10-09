using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MenuBarProject.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        Frame GetRightPaneFrame();

        void ShowWindow();

        SplitView GetSplitView();
    }
}
