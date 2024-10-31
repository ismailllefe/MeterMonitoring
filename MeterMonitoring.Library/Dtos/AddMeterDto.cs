
namespace MeterMonitoring.Library.Dtos
{
    public class AddMeterDto
    {
        public string SerialNumber { get; set; }
        public DateTime ReadingTime { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double LastIndex { get; set; }
    }
}
