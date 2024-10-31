using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Models
{
    [Table("MeterDatas", Schema = "Main")]
    public class MeterData
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SerialNumber { get; set; }
        public DateTime ReadingTime { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double LastIndex { get; set; }
    }
}
