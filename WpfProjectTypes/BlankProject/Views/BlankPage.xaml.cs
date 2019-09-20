using System.Windows.Controls;
using BlankProject.ViewModels;

namespace BlankProject.Views
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