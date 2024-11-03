using System.ComponentModel.DataAnnotations;

namespace MeterMonitoring.Library.Dtos
{
    public class NewClientRequestDto
    {
        [MaxLength(2048, ErrorMessage = "too_long_text")]
        public string SerialNumber { get; set; }

        public DateTime Date { get; set; }
    }
}
