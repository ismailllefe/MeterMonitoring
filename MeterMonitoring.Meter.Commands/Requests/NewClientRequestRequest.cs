using MediatR;
using MeterMonitoring.Library.Dtos;
using MeterMonitoring.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Meter.Commands.Requests
{
    public class NewClientRequestRequest : IRequest<ApiResult<NewClientResult>>
    {
        public NewClientRequestRequest(NewClientRequestDto data)
        {
            Data = data;
        }

        public NewClientRequestDto Data { get; }
    }
}