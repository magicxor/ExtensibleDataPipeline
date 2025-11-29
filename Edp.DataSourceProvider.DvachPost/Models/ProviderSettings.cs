using System.ComponentModel.DataAnnotations;

namespace Edp.DataSourceProvider.DvachPost.Models
{
    public class ProviderSettings
    {
        [Required]
        public string Hostname { get; set; }
    }
}
