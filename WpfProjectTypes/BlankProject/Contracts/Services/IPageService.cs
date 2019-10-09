using System;
using System.Windows.Controls;

namespace BlankProject.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
