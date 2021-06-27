namespace Phyros.ReferenceArchitecture.DomainModels
{
	public class Temperature
	{
		private decimal _temperatureInCelsius;

		public Temperature(decimal temperature, TemperatureUnitKind unitKind)
		{
			switch (unitKind)
			{
				case TemperatureUnitKind.Celsius:
					_temperatureInCelsius = temperature;
					break;
				case TemperatureUnitKind.Fahrenheit:
					_temperatureInCelsius = ConvertFromFahrenheit(temperature);
					break;
				case TemperatureUnitKind.Kelvin:
					_temperatureInCelsius = ConvertFromKelvin(temperature);
					break;
			}
		}

		public decimal AsFahrenheit => ConvertToFahrenheit(_temperatureInCelsius);

		public decimal AsKelvin => ConvertToKelvin(_temperatureInCelsius);

		public decimal AsCelsius => _temperatureInCelsius;

		private decimal ConvertFromKelvin(in decimal temperature)
		{
			return temperature - 273.15M;
		}

		private decimal ConvertFromFahrenheit(in decimal temperature)
		{
			return (temperature - 32M) * 5M / 9M;
		}

		private decimal ConvertToFahrenheit(in decimal temperatureInCelsius)
		{
			return (temperatureInCelsius * 9M / 5M) + 32M;
		}

		private decimal ConvertToKelvin(in decimal temperatureInCelsius)
		{
			return temperatureInCelsius + 273.15M;
		}

		public void AddCelsius(decimal temperature)
		{
			_temperatureInCelsius += temperature;
		}
	}
}
