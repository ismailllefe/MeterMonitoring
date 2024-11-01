using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Data.Services.Abstractions
{
    public interface IReportService
    {
        Task<ApiResult<List<RequestListDto>>> GetListByType(ListRequestRequest request, CancellationToken cancellationToken);

        Task<ApiResult<NewClientResult>> Create(NewClientRequestDto dto, CancellationToken cancellationToken);
        Task<ApiResult<bool>> GetReport(Guid id, CancellationToken cancellationToken);
    }
}
