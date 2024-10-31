using AutoMapper;
using DatabaseLibrary.Data;
using DatabaseLibrary.Models;
using MediatR;
using MeterMonitoring.Common.Services.Concretes;
using MeterMonitoring.Library;
using MeterMonitoring.Meter.Commands.Requests;

namespace MeterMonitoring.Meter.Commands.Queries;

public class AddMeterCommand : IRequestHandler<AddMeterRequest, ApiResult<bool>>
{
    private readonly MeterMonitoringContext context;
    private readonly IMapper mapper;
    //private readonly RabbitMqService rabbitMQService;

    public AddMeterCommand(MeterMonitoringContext context, IMapper mapper)//, RabbitMqService rabbitMQService)
    {
        this.context = context;
        this.mapper = mapper;
        //this.rabbitMQService = rabbitMQService;
    }

    public async Task<ApiResult<bool>> Handle(AddMeterRequest request, CancellationToken cancellationToken)
    {
        if (request.Data == null)
        {
            return new ApiResult<bool>(false, state: State.Warning);
        }
        //var entity = new MeterData
        //{
        //    Id = new Guid(),
        //    SerialNumber = "12345",
        //    Current = 1,
        //    LastIndex = 3,
        //    ReadingTime = DateTime.UtcNow,
        //    Voltage = 5
        //};
        var entity = mapper.Map<MeterData>(request.Data);

        await context.Meters.AddAsync(entity);

        var result = await context.SaveChangesAsync();
        if (result == 0)
        {
            return new ApiResult<bool>(false, state: State.Warning);
        }
        return new ApiResult<bool>(true, state: State.Success);
    }
}