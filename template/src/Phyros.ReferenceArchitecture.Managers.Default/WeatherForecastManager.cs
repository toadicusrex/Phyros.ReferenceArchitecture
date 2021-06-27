using System;
using System.Collections.Generic;
using System.Linq;
using Phyros.ReferenceArchitecture.DomainModels;
using Phyros.ReferenceArchitecture.Engines;
using Phyros.ReferenceArchitecture.Infrastructure;

namespace Phyros.ReferenceArchitecture.Managers.Default
{
	public class WeatherForecastManager : IWeatherForecastManager
	{
		private readonly IWeatherDataRepository _weatherDataRepository;
		private readonly IWeatherForecastCalculator _forecastCalculator;

		public WeatherForecastManager(IWeatherDataRepository weatherDataRepository, IWeatherForecastCalculator forecastCalculator)
		{
			_weatherDataRepository = weatherDataRepository;
			_forecastCalculator = forecastCalculator;
		}

		public IEnumerable<WeatherForecast> GetForecast()
		{
			var satelliteData = _weatherDataRepository.GetSatelliteData().ToList();
			if (!satelliteData.Any())
			{
				throw new InvalidOperationException("Unable to calculate forecast as satellite data could not be retrieved from Satellite Weather Data Repository.");
			}
			//we only want the last record
			var yesterdaysRecord = satelliteData.Last();
			var forecast = _forecastCalculator.CalculateForecast(yesterdaysRecord.Date, new Temperature(yesterdaysRecord.HighInCelsius, TemperatureUnitKind.Celsius), new Temperature(yesterdaysRecord.LowInCelsius, TemperatureUnitKind.Celsius), yesterdaysRecord.RelativeHumidity);
			return forecast;
		}
	}
}
