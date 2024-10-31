using MediatR;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;

namespace MeterMonitoring.Meter.Commands.Requests
{
    public class AddMeterRequest : IRequest<ApiResult<bool>>
    {
        public AddMeterRequest(AddMeterDto data)
        {
            Data = data;
        }

        public AddMeterDto Data { get; }
    }
}
