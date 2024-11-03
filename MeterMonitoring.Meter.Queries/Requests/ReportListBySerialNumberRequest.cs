using MediatR;
using MeterMonitoring.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Meter.Queries.Requests
{
    public class ReportListBySerialNumberRequest : IRequest<ApiResult<List<ReportListDto>>>
    {
        public ReportListBySerialNumberRequest(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; }
    }
}
