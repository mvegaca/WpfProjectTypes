using System.Windows.Controls;

namespace BlankProject.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();
    }
}