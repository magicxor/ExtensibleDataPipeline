using System.ComponentModel.DataAnnotations;

namespace Edp.DataSourceProvider.DvachThread.Models
{
    public class ProviderSettings
    {
        [Required]
        public string Hostname { get; set; }
    }
}
