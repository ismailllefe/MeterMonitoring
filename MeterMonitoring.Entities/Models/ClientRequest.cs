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
    [Table("ClientRequests", Schema = "Main")]
    public class ClientRequest
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public RequestState RequestState { get; set; }

        public DateTimeOffset? Date { get; set; }
    }
}
