using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Edp.DataSourceProvider.VkFeed.Dto;
using Edp.Common.Utils;
using Edp.DataSourceProvider.VkFeed.Extensions;

namespace Edp.DataSourceProvider.VkFeed.Services
{
    public class Renderer
    {
        public List<string> RenderAsPlainText(IEnumerable<ResponseItem> responseItems)
        {
            return responseItems
                .Select(ri =>
                    DateTimeUtils.TimestampToUtcDateTime(ri.Date).ToString("dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                    + " " + ri.PostUri()
                    + (ri.SignerId.HasValue ? " " + ri.SignerUri() : string.Empty)
                    + " " + ri.Text)
                .ToList();
        }
    }
}
