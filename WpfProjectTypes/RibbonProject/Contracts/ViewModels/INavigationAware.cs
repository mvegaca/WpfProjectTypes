namespace RibbonProject.Contracts.ViewModels
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object parameter);

        void OnNavigatingFrom();
    }
}