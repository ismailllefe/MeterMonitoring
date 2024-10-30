using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Models;
    public class MeterMonitoring
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SerialNumber { get; set; }
        public DateTime ReadingTime { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double LastIndex { get; set; }
    }

