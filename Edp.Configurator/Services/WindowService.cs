using System.Windows;
using Edp.Configurator.ViewModel;

namespace Edp.Configurator.Services
{
    public class WindowService
    {
        public void ShowDialogWindow(Window owner, DialogViewModel viewModel)
        {
            var dialogWindow = new DialogWindow(owner, viewModel);
            dialogWindow.ShowDialog();
        }
    }
}
