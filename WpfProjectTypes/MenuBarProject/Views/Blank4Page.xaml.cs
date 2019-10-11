using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    public partial class Blank4Page : Page
    {
        public Blank4Page(Blank4ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
