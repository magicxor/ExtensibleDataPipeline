using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class VkNewsFeedGetResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
