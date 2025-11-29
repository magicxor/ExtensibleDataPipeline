using System;
using System.Collections.Generic;
using System.Linq;
using Edp.DataSourceProvider.TelegramChannel.Dto;

namespace Edp.DataSourceProvider.TelegramChannel.Services
{
    public class Renderer
    {
        public List<string> RenderAsPlainText(IEnumerable<Post> posts)
        {
            var resultItems = posts
                .Select(p => p.Link + Environment.NewLine + p.Text)
                .ToList();
            return resultItems;
        }
    }
}
