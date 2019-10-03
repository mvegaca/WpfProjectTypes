using System.Windows.Controls;
using Fluent;
using RibbonProject.Behaviors;

namespace RibbonProject.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        Frame GetRightPaneFrame();

        RibbonTabsBehavior GetRibbonTabsBehavior();

        void ShowWindow();

        void OpenRightPane();
    }
}
