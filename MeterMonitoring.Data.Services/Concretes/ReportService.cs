using MediatR;
using MeterMonitoring.Data.Services.Abstractions;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;
using MeterMonitoring.Meter.Commands.Requests;
using MeterMonitoring.Meter.Queries.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Data.Services.Concretes
{
    public class ReportService : IReportService
    {
        private readonly IMediator mediator;

        public ReportService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task<ApiResult<NewClientResult>> Create(NewClientRequestDto dto, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewClientRequestRequest(dto), cancellationToken);
        }

        public Task<ApiResult<List<ReportListDto>>> GetReportList(string serialNumber, CancellationToken cancellationToken)
        {
            return mediator.Send(new ReportListBySerialNumberRequest(serialNumber), cancellationToken);
        }

        public Task<ApiResult<ReportDto>> GetReport(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
