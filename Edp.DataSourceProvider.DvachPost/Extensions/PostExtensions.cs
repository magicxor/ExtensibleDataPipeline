using System.Web;
using Edp.DataSourceProvider.DvachPost.Dto.ThreadDto;

namespace Edp.DataSourceProvider.DvachPost.Extensions
{
    public static class PostExtensions
    {
        public static string SubjectDecoded(this Post post)
        {
            return string.IsNullOrEmpty(post.Subject)
                ? string.Empty
                : HttpUtility.HtmlDecode(post.Subject);
        }
    }
}