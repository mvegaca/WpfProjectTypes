using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    public partial class Blank1Page : Page
    {
        public Blank1Page(Blank1ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
