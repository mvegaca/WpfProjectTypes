using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    /// <summary>
    /// Interaction logic for Blank2Page.xaml
    /// </summary>
    public partial class Blank2Page : Page
    {
        public Blank2Page(Blank2ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
