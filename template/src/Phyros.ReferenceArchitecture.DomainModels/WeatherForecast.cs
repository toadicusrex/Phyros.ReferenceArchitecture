using System;

namespace Phyros.ReferenceArchitecture.DomainModels
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }
		public Temperature High { get; set; }
		public Temperature Low { get; set; }
		public int PrecipitationChance { get; set; }
		public int RelativeHumidity { get; set; }
		public string PrecipitationKind { get; set; }
	}
}
