using System.Collections.Generic;

namespace Edp.DataSourceProvider.VkFeed.Models
{
    public class EndpointOptions
    {
        public int? MaxDaysFromNow { get; set; }
        public bool? IsFemale { get; set; }
        public List<string> IncludedPatterns { get; set; } = new List<string>();
        public List<string> ExcludedPatterns { get; set; } = new List<string>();
    }
}
