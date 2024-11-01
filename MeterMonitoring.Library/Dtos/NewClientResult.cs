using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Library.Dtos
{
    public class NewClientResult
    {
        public bool Result { get; set; }
        public Guid? RequestId { get; set; }
    }
}
