using System;

namespace Phyros.ReferenceArchitecture.Infrastructure.ReferenceModels
{
	public class WeatherRecord
	{
		public DateTime Date { get; set; }
		public decimal HighInCelsius { get; set; }
		public decimal LowInCelsius { get; set; }
		public int RelativeHumidity { get; set; }
	}
}
