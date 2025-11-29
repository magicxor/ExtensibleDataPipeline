using Edp.Common.Abstractions;
using Edp.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Edp.DataSourceProvider.TelegramChannel.Models;
using Edp.DataSourceProvider.TelegramChannel.Services;

namespace Edp.DataSourceProvider.TelegramChannel
{
    [Export(typeof(IDataSourceProvider))]
    public class TelegramChannelDataSourceProvider : IDataSourceProvider
    {
        public async Task<IDataFetchResult> GetNewItemsAsPlainTextAsync(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, 
            string endpointOptionsString, 
            string stateString,
            CancellationToken cancellationToken)
        {
            var providerSettings = configurationRoot.GetSection(GetType().Name).Get<ProviderSettings>();
            var endpointOptions = JsonConvert.DeserializeObject<EndpointOptions>(endpointOptionsString);
            var state = JsonConvert.DeserializeObject<State>(stateString) ?? new State();
            var dataExtractor = new DataExtractor(loggerFactory);
            var renderer = new Renderer();

            var extractedItems = await dataExtractor.ExtractAsync(providerSettings, state, endpointOptions);
            var filteredItems = dataExtractor.Filter(extractedItems, state, endpointOptions);
            var renderedItems = renderer.RenderAsPlainText(filteredItems);

            var lastItem = extractedItems.LastOrDefault();
            if (lastItem != null)
            {
                state.LastRecordId = lastItem.Id;
            }

            var result = new DataFetchResult
            {
                Items = renderedItems,
                State = JsonConvert.SerializeObject(state),
            };
            return result;
        }

        public Type GetEndpointOptionsType()
        {
            return typeof(EndpointOptions);
        }

        public Type GetProviderSettingsType()
        {
            return typeof(ProviderSettings);
        }
    }
}
