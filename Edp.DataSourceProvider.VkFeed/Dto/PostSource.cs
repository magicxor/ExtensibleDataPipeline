using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class PostSource
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
    }
}