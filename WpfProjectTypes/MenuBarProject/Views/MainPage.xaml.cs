using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
