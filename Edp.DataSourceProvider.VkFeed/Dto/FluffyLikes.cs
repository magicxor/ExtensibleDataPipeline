using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class FluffyLikes
    {
        [JsonProperty("user_likes")]
        public long UserLikes { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}