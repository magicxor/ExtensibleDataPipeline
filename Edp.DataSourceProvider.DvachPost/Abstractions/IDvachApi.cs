using System.Threading;
using System.Threading.Tasks;
using Edp.DataSourceProvider.DvachPost.Dto.BoardDto;
using Edp.DataSourceProvider.DvachPost.Dto.ThreadDto;
using Refit;

namespace Edp.DataSourceProvider.DvachPost.Abstractions
{
    public interface IDvachApi
    {
        [Get("/{boardId}/catalog_num.json")]
        Task<DvachBoardDto> GetBoard(string boardId, CancellationToken cancellationToken);

        [Get("/{boardId}/res/{threadId}.json")]
        Task<DvachThreadDto> GetThread(string boardId, string threadId, CancellationToken cancellationToken);
    }
}
