using System.Windows;
using Edp.Configurator.ViewModel;

namespace Edp.Configurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
