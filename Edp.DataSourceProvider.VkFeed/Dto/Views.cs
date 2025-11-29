using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class Views
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}