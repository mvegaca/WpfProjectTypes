using System;
using System.Windows.Controls;

namespace MenuBarProject.Contracts.Services
{
    public interface IRightPaneService
    {
        void OpenInRightPane(string viewModelName, object parameter = null);

        void Initialize(Frame rightPaneFrame, Action openRightPane);
    }
}
