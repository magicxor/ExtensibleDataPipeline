using System.Collections.Generic;

namespace Edp.Core.Models
{
    public class DataFlow
    {
        public string Name { get; set; }
        public EndpointInfo Source { get; set; }
        public IList<EndpointInfo> Targets { get; set; }
    }
}
