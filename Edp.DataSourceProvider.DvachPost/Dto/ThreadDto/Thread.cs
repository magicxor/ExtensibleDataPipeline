using System.Collections.Generic;
using Newtonsoft.Json;

namespace Edp.DataSourceProvider.DvachPost.Dto.ThreadDto
{
    public class Thread
    {
        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }
    }
}