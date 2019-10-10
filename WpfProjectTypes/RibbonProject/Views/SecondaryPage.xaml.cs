using System.Windows.Controls;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
{
    public partial class SecondaryPage : Page
    {
        public SecondaryPage(SecondaryViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
