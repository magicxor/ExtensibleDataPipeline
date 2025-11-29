using System.ComponentModel.DataAnnotations;

namespace Edp.DataSourceProvider.VkFeed.Models
{
    public class ProviderSettings
    {
        [Required]
        public string AccessToken { get; set; }
    }
}
