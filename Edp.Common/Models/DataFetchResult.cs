using System.Collections.Generic;
using Edp.Common.Abstractions;

namespace Edp.Common.Models
{
    public class DataFetchResult: IDataFetchResult
    {
        public IList<string> Items { get; set; }
        public string State { get; set; }
    }
}
