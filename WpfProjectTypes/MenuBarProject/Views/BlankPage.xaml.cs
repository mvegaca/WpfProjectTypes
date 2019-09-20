using System.Windows.Controls;
using MenuBarProject.ViewModels;

namespace MenuBarProject.Views
{
    /// <summary>
    /// Interaction logic for BlankPage.xaml
    /// </summary>
    public partial class BlankPage : Page
    {
        public BlankPage(BlankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
