using AutoMapper;
using DatabaseLibrary.Data;
using DatabaseLibrary.Models;
using MediatR;
using MeterMonitoring.Common.Services.Concretes;
using MeterMonitoring.Library;
using MeterMonitoring.Meter.Commands.Requests;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeterMonitoring.Meter.Commands.Queries;

public class AddMeterCommand : IRequestHandler<AddMeterRequest, ApiResult<bool>>
{
    private MeterMonitoringContext context;
    private readonly IMapper mapper;
    private readonly RabbitMqService rabbitMQService;

    public AddMeterCommand(MeterMonitoringContext context, IMapper mapper, RabbitMqService rabbitMQService)
    {
        this.context = context;
        this.mapper = mapper;
        this.rabbitMQService = rabbitMQService;
    }

    public async Task<ApiResult<bool>> Handle(AddMeterRequest request, CancellationToken cancellationToken)
    {
        if (request.Data == null)
        {
            return new ApiResult<bool>(false, state: State.Warning);
        }

        var entity = mapper.Map<MeterData>(request.Data);

        await context.Meters.AddAsync(entity);

        var result = await context.SaveChangesAsync();
        if (result == 0)
        {
            return new ApiResult<bool>(false, state: State.Error);
        }
        return new ApiResult<bool>(true, state: State.Success);
    }
}