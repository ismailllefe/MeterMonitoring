namespace MeterMonitoring.Dtos
{
    public class MeterListResultDto
    {
        public string SerialNumber { get; set; }
        public DateTime ReadingTime { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double LastIndex { get; set; }
    }
}
