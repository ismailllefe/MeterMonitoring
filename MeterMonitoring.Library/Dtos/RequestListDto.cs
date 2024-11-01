using MeterMonitoring.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Library.Dtos
{
    public class RequestListDto
    {
        public RequestState State { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Date { get; set; }
    }
}
