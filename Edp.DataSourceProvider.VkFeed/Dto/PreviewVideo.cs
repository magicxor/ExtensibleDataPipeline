using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class PreviewVideo
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("file_size")]
        public long FileSize { get; set; }
    }
}