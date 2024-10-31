using MediatR;
using MeterMonitoring.Dtos;
using MeterMonitoring.Library;

namespace MeterMonitoring.Meter.Queries.Requests
{
    public class MeterListBySerialNumberRequest : IRequest<ApiResult<List<MeterListResultDto>>>
    {
        public MeterListBySerialNumberRequest(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; }
    }
}
