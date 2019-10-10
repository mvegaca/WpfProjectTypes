using System.Windows.Controls;
using BlankProject.ViewModels;

namespace BlankProject.Views
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
