using System;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Edp.DataSourceProvider.VkFeed.Abstractions;
using Edp.DataSourceProvider.VkFeed.Models;
using Edp.DataSourceProvider.VkFeed.Services;
using Edp.Common.Abstractions;
using Edp.Common.Models;
using Edp.Common.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Refit;

namespace Edp.DataSourceProvider.VkFeed
{
    [Export(typeof(IDataSourceProvider))]
    public class VkFeedDataSourceProvider : IDataSourceProvider
    {
        private readonly Renderer _renderer = new Renderer();
        private readonly DataExtractor _dataExtractor = new DataExtractor();

        public async Task<IDataFetchResult> GetNewItemsAsPlainTextAsync(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, 
            string endpointOptionsString, 
            string stateString,
            CancellationToken cancellationToken)
        {
            var logger = loggerFactory.CreateLogger<VkFeedDataSourceProvider>();
            var providerSettings = configurationRoot.GetSection(GetType().Name).Get<ProviderSettings>();
            var endpointOptions = JsonConvert.DeserializeObject<EndpointOptions>(endpointOptionsString);
            var state = JsonConvert.DeserializeObject<State>(stateString) ?? new State();

            var siteUri = new Uri("https://api.vk.com");
            var api = RestService.For<IVkApi>(siteUri.ToString(), new RefitSettings {
                ContentSerializer = new NewtonsoftJsonContentSerializer(),
            });
            var extractedItems = await _dataExtractor.ExtractAsync(logger, api, providerSettings, state, endpointOptions, cancellationToken);
            var filteredItems = _dataExtractor.Filter(extractedItems, state, endpointOptions);
            var renderedItems = _renderer.RenderAsPlainText(filteredItems);

            var lastItem = extractedItems.ResponseItems.LastOrDefault();
            if (lastItem != null)
            {
                state.LastRecordCreatedUtc = DateTimeUtils.TimestampToUtcDateTime(lastItem.Date);
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
