using DatabaseLibrary.Data;
using MediatR;
using MeterMonitoring.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;
using MeterMonitoring.Meter.Queries.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Meter.Queries.Queries
{
    public class ReportListBySerialNumberQuery : IRequestHandler<ReportListBySerialNumberRequest, ApiResult<List<ReportListDto>>>
    {
        private readonly MeterMonitoringContext context;
        public ReportListBySerialNumberQuery(MeterMonitoringContext context)
        {
            this.context = context;
        }
        public async Task<ApiResult<List<ReportListDto>>> Handle(ReportListBySerialNumberRequest request, CancellationToken cancellationToken)
        {
            var result = context.Reports.Where(r => r.SerialNumber == request.SerialNumber).OrderByDescending(r => r.RequestedDate)
                .Select(s => new ReportListDto
                {
                    Content = s.Content,
                    RequestedDate = s.RequestedDate,
                })
                .ToList();

            return new ApiResult<List<ReportListDto>>(result);
        }
    }
}
