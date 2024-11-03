using MeterMonitoring.Library.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Models
{
    [Table("Reports", Schema = "Main")]
    public class Report
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public RequestState RequestState { get; set; }

        public DateTimeOffset? RequestedDate { get; set; }

        public string SerialNumber { get; set; }
        public string Content { get; set; }

    }
}
