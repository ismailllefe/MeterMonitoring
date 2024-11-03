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
        Task<ApiResult<NewClientResult>> Create(NewClientRequestDto dto, CancellationToken cancellationToken);
        Task<ApiResult<ReportDto>> GetReport(Guid id, CancellationToken cancellationToken);
        Task<ApiResult<List<ReportListDto>>> GetReportList(string serialNumber, CancellationToken cancellationToken);
    }
}
