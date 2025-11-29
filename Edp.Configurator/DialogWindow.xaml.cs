using System.Windows;
using Edp.Configurator.Interfaces;
using Edp.Configurator.ViewModel;

namespace Edp.Configurator
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window, IClosable
    {
        private readonly DialogViewModel _viewModel;

        public DialogWindow(Window owner, DialogViewModel viewModel)
        {
            this.Owner = owner;
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
