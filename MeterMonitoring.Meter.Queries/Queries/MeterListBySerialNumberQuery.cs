using DatabaseLibrary.Data;
using MediatR;
using MeterMonitoring.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Meter.Queries.Requests;

namespace MeterMonitoring.Meter.Queries.Queries
{
    public class MeterListBySerialNumberQuery : IRequestHandler<MeterListBySerialNumberRequest, ApiResult<List<MeterListResultDto>>>
    {
        private readonly MeterMonitoringContext context;

        public MeterListBySerialNumberQuery(MeterMonitoringContext context)
        {
            this.context = context;
        }
        public async Task<ApiResult<List<MeterListResultDto>>> Handle(MeterListBySerialNumberRequest request, CancellationToken cancellationToken)
        {
            var result = context.Meters
             .Where(r => r.SerialNumber == request.SerialNumber)
             .OrderByDescending(r => r.ReadingTime).Select(s => new MeterListResultDto
             {
                 Current = s.Current,
                 LastIndex = s.LastIndex,
                 ReadingTime = s.ReadingTime,
                 SerialNumber = s.SerialNumber,
                 Voltage = s.Voltage
             })
             .ToList();

            return new ApiResult<List<MeterListResultDto>>(result);

        }
    }
}
