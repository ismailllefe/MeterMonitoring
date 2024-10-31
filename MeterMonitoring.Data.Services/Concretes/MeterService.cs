using MediatR;
using MeterMonitoring.Data.Services.Abstractions;
using MeterMonitoring.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;
using MeterMonitoring.Meter.Commands.Requests;
using MeterMonitoring.Meter.Queries.Requests;

namespace MeterMonitoring.Data.Services.Concretes;

public class MeterService : IMeterService
{
    private readonly IMediator mediator;
    public MeterService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<ApiResult<bool>> Add(AddMeterDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new AddMeterRequest(data), cancellationToken);
    }

    public Task<ApiResult<List<MeterListResultDto>>> GetMeterListBySerialNumber(string serialNumber, CancellationToken cancellationToken)
    {
        return mediator.Send(new MeterListBySerialNumberRequest(serialNumber), cancellationToken);
    }
}

