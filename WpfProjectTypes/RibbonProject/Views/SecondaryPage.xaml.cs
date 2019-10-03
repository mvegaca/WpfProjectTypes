using System.Windows.Controls;
using RibbonProject.ViewModels;

namespace RibbonProject.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class SecondaryPage : Page
    {
        public SecondaryPage(SecondaryViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
