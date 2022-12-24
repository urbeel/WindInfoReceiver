
namespace PortsApp.Entity
{
    internal class WindInfo
    {
        public DateTime Date { get; set; }

        public string SensorName { get; set; }

        public double WindSpeed { get; set; }

        public double WindDirection { get; set; }

        public WindInfo(DateTime date, string sensorName, double windSpeed, double windDirection)
        {
            Date = date;
            SensorName = sensorName;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
        }

        public override string ToString()
        {
            return $"{nameof(Date)}: {Date}, {nameof(SensorName)}: {SensorName}, {nameof(WindSpeed)}: {WindSpeed}, {nameof(WindDirection)}: {WindDirection}";
        }
    }
}
