using System.Windows.Controls;

namespace MenuBarProject.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        Frame GetRightPaneFrame();        

        void ShowWindow();

        void OpenRightPane();
    }
}
