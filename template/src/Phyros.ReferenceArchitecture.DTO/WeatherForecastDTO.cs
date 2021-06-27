using System;

namespace Phyros.ReferenceArchitecture.DTO
{
	public class WeatherForecastDTO
	{
		public DateTime Date { get; set; }
		public decimal HighCelsius { get; set; }
		public decimal HighFahrenheit { get; set; }
		public decimal LowCelsius { get; set; }
		public decimal LowFahrenheit { get; set; }
		public int RelativeHumidityPercentage { get; set; }
		public int PrecipitationChancePercentage { get; set; }
		public string PrecipitationKind { get; set; }
	}
}
