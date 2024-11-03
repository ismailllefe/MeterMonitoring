using MeterMonitoring.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Library.Dtos
{
    public class ReportListDto
    {
        public DateTimeOffset? RequestedDate { get; set; }
        public string Content { get; set; }
    }
}
