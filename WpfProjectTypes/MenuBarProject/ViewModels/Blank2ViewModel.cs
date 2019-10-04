using System.Windows.Input;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class Blank2ViewModel : Observable
    {
        private string _otherWindowsData;
        private string _dataToSend;
        private ICommand _sendCommand;
        private IWindowManagerService _windowManagerService;
        private INavigationService _navigationService;

        public string OtherWindowsData
        {
            get { return _otherWindowsData; }
            set { Set(ref _otherWindowsData, value); }
        }

        public string DataToSend
        {
            get { return _dataToSend; }
            set { Set(ref _dataToSend, value); }
        }

        public ICommand SendCommand => _sendCommand ?? (_sendCommand = new RelayCommand(OnSend));

        public Blank2ViewModel(IWindowManagerService windowManagerService, INavigationService navigationService)
        {
            _windowManagerService = windowManagerService;
            _navigationService = navigationService;
        }

        private void OnSend()
        {
            var mainViewModel = _navigationService.CurrentViewModel as MainViewModel;
            mainViewModel.OtherWindowsData = DataToSend;
        }
    }
}
