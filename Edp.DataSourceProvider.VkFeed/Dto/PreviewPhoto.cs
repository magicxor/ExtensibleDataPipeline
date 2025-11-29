using System.Collections.Generic;
using Newtonsoft.Json;

namespace Edp.DataSourceProvider.VkFeed.Dto
{
    public class PreviewPhoto
    {
        [JsonProperty("sizes")]
        public List<PurpleSize> Sizes { get; set; }
    }
}