using System.Windows.Controls;

namespace RibbonProject.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        Frame GetRightPaneFrame();

        void ShowWindow();

        void OpenRightPane();
    }
}
