namespace BlankProject.Contracts.ViewModels
{
    public interface INavigationAware
    {
        void OnNavigatedTo(object ExtraData);

        void OnNavigatingFrom();
    }
}
