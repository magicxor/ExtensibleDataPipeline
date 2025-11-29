using System.Web;
using Edp.DataSourceProvider.DvachThread.Dto;

namespace Edp.DataSourceProvider.DvachThread.Extensions
{
    public static class ThreadExtensions
    {
        public static string SubjectDecoded(this Thread thread)
        {
            return string.IsNullOrEmpty(thread.Subject)
                ? string.Empty
                : HttpUtility.HtmlDecode(thread.Subject);
        }
    }
}
