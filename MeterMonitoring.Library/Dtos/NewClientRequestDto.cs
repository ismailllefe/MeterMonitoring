using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Library.Dtos
{
    public class NewClientRequestDto
    {
        [Required(ErrorMessage = "requied")]
        [MaxLength(64, ErrorMessage = "too_long_text")]
        public string Name { get; set; }

        [MaxLength(2048, ErrorMessage = "too_long_text")]
        public string Payload { get; set; }
    }
}
