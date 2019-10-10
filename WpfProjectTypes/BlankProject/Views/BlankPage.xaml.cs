using System.Windows.Controls;
using BlankProject.ViewModels;

namespace BlankProject.Views
{
    public partial class BlankPage : Page
    {
        public BlankPage(BlankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}