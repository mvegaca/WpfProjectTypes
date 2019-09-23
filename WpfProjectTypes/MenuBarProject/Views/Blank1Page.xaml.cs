using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    /// <summary>
    /// Interaction logic for BlankPage.xaml
    /// </summary>
    public partial class Blank1Page : Page
    {
        public Blank1Page(Blank1ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
