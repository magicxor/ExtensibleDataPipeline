using System;
using System.IO;
using System.Reflection;
using Edp.Core.Constants;
using Edp.Core.Models;
using Edp.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Schema.Generation;

namespace Edp.Cli.NetCore.DependencyInjection;

public static class ContainerConfiguration
{
    private static ILoggerFactory CreateLoggerFactory(ApplicationSettings applicationSettings)
    {
        var logPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? throw new InvalidOperationException(), applicationSettings.LogDirectoryName, "log-{Date}.txt");
        var loggerFactory = LoggerFactory.Create(builder => builder
            .AddConsole()
            .AddFile(logPath, applicationSettings.LogLevel, retainedFileCountLimit: 10)
        );
        return loggerFactory;
    }

    public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        var applicationSettings = configurationRoot
            .GetRequiredSection(Defaults.ConfigurationSectionName)
            .Get<ApplicationSettings>() ?? throw new InvalidOperationException("Cannot load application settings from configuration.");

        services
            .AddSingleton(configurationRoot)
            .AddSingleton(applicationSettings)
            .AddScoped<ILoggerFactory>(c => CreateLoggerFactory(applicationSettings))
            .AddScoped<JSchemaGenerator>()
            .AddScoped<IPluginManager, PluginManager>()
            .AddScoped<DataPipelineService>();
    }
}
