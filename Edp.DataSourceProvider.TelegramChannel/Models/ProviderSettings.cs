using System.ComponentModel.DataAnnotations;
using Edp.DataSourceProvider.TelegramChannel.Enums;

namespace Edp.DataSourceProvider.TelegramChannel.Models
{
    public class ProviderSettings
    {
        [Required]
        public string Hostname { get; set; }
        
        [Required]
        public ProxyProtocols ProxyProtocol { get; set; }

        public string ProxyHost { get; set; }
        public int ProxyPort { get; set; }
        public bool ProxyAuthentication { get; set; }
        public string ProxyUsername { get; set; }
        public string ProxyPassword { get; set; }
    }
}
