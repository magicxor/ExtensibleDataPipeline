using System.Collections.Generic;
using Edp.DataSourceProvider.VkFeed.Dto;

namespace Edp.DataSourceProvider.VkFeed.Models
{
    public class VkNewsfeedResult
    {
        public List<Profile> Profiles { get; set; }
        public List<ResponseItem> ResponseItems { get; set; }
    }
}
