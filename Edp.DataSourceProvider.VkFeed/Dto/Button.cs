using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class Button
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("action")]
        public Action Action { get; set; }
    }
}