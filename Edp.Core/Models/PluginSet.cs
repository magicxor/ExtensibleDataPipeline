using System.Collections.Generic;
using Edp.Common.Abstractions;

namespace Edp.Core.Models
{
    public class PluginSet
    {
        public IList<IDataSourceProvider> DataSourceProviders { get; set; }
        public IList<ITargetProvider> TargetProviders { get; set; }
    }
}
