using System.Windows.Input;
using MenuBarProject.Contracts.Services;
using MenuBarProject.Helpers;

namespace MenuBarProject.ViewModels
{
    public class MainViewModel : Observable
    {
        private string _otherWindowsData;
        private string _dataToSend;
        private ICommand _sendCommand;
        private IWindowManagerService _windowManagerService;

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

        public MainViewModel(IWindowManagerService windowManagerService)
        {
            _windowManagerService = windowManagerService;
        }

        private void OnSend()
        {
            var viewModelName = typeof(Blank2ViewModel).FullName;
            var viewModel = _windowManagerService.GetViewModel(viewModelName) as Blank2ViewModel;
            viewModel.OtherWindowsData = DataToSend;
        }
    }
}
