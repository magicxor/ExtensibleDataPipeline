using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Edp.Configurator.DependencyInjection;

namespace Edp.Configurator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var container = ContainerConfiguration.CreateServiceProvider();
            var mainWindow = container.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
