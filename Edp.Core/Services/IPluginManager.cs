using Edp.Core.Models;

namespace Edp.Core.Services
{
    public interface IPluginManager
    {
        PluginSet LoadPlugins();
    }
}
