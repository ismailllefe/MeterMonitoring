using AutoMapper;
using MediatR;
using MeterMonitoring.Common.Services.Concretes;
using MeterMonitoring.Library.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Meter.Commands.Requests;
using DatabaseLibrary.Data;
using DatabaseLibrary.Models;

namespace MeterMonitoring.Meter.Commands.Queries
{
    public class NewClientRequestCommand : IRequestHandler<NewClientRequestRequest, ApiResult<NewClientResult>>
    {
        private MeterMonitoringContext context;
        private readonly IMapper mapper;
        private readonly RabbitMqService rabbitMqService;

        public NewClientRequestCommand(RabbitMqService rabbitMqService, IMapper mapper, MeterMonitoringContext context)
        {
            this.rabbitMqService = rabbitMqService;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ApiResult<NewClientResult>> Handle(NewClientRequestRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ClientRequest>(request.Data);
            await context.ClientRequests.AddAsync(entity);

            var result = await context.SaveChangesAsync();
            if (result <= 0)
            {
                return new ApiResult<NewClientResult>(new NewClientResult { Result = false }, "not_saved", State.Error);
            }

            rabbitMqService.Publish("Request", entity.Id);

            return new ApiResult<NewClientResult>(new NewClientResult { RequestId = entity.Id, Result = true });
        }
    }
}
