using System.Windows.Controls;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
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
