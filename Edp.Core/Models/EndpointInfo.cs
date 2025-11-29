using Edp.Common.Abstractions;

namespace Edp.Core.Models
{
    public class EndpointInfo: IEndpointInfo
    {
        public string ProviderName { get; set; }
        public string EndpointOptions { get; set; }
    }
}
