using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using Edp.Cli.NetCore.DependencyInjection;
using Edp.Core.Constants;
using Edp.Core.Models;
using Edp.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edp.Cli.NetCore;

internal static class Program
{
    // see: https://docs.microsoft.com/en-us/windows/desktop/Debug/system-error-codes
    private const int Success = 0;
    private const int ErrorBadArguments = 160;

    private static readonly CancellationTokenSource CancelTokenSource = new();

    private static IConfigurationRoot GetConfigurationRoot()
    {
        var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? Directory.GetCurrentDirectory();
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddJsonFile(Defaults.ConfigurationFileName);
        var configurationRoot = configurationBuilder.Build();
        return configurationRoot;
    }

    private static ServiceProvider CreateServiceProvider(IConfigurationRoot configurationRoot)
    {
        var serviceCollection = new ServiceCollection();
        ContainerConfiguration.ConfigureServices(serviceCollection, configurationRoot);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        return serviceProvider;
    }

    private static async Task<int> OnParsedAsync(CommandLineOptions commandLineOptions)
    {
        var configurationRoot = GetConfigurationRoot();
        var serviceProvider = CreateServiceProvider(configurationRoot);
        var applicationSettings = configurationRoot
            .GetRequiredSection(Defaults.ConfigurationSectionName)
            .Get<ApplicationSettings>() ?? throw new InvalidOperationException("Cannot load application settings from configuration.");
        var dataPipelineService = serviceProvider.GetRequiredService<DataPipelineService>();

        var cancellationToken = CancelTokenSource.Token;
        Console.CancelKeyPress += (_, a) =>
        {
            CancelTokenSource.Cancel();
            a.Cancel = true;
        };

        if (commandLineOptions.GenerateSchema)
        {
            string jsonSchemasDirectory;
            if (string.IsNullOrWhiteSpace(commandLineOptions.Directory))
            {
                jsonSchemasDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? Directory.GetCurrentDirectory();
            }
            else
            {
                Directory.CreateDirectory(commandLineOptions.Directory);
                jsonSchemasDirectory = commandLineOptions.Directory;
            }
            dataPipelineService.GenerateJsonSchemas(jsonSchemasDirectory);
        }
        else
        {
            await dataPipelineService.RunOnceAsync(applicationSettings.DataFlows, cancellationToken);
        }

        return Success;
    }

    private static Task<int> OnNotParsed(IEnumerable<Error> errors)
    {
        return Task.FromResult(ErrorBadArguments);
    }

    private static async Task<int> Main(string[] args)
    {
        using var parser = new Parser(settings =>
        {
            settings.CaseSensitive = true;
            settings.IgnoreUnknownArguments = false;
            settings.HelpWriter = Console.Error;
        });
        var exitCode = await parser.ParseArguments<CommandLineOptions>(args)
            .MapResult(OnParsedAsync, OnNotParsed);
        return exitCode;
    }
}
