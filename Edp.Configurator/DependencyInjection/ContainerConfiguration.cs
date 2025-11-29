using Microsoft.Extensions.DependencyInjection;
using System;
using Edp.Configurator.Services;
using Edp.Configurator.ViewModel;

namespace Edp.Configurator.DependencyInjection
{
    public static class ContainerConfiguration
    {
        public static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<WindowService>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<MainWindow>()
                .BuildServiceProvider();
        }
    }
}
