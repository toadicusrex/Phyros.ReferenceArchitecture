using System;
using System.Collections.Generic;
using Phyros.ReferenceArchitecture.DomainModels;

namespace Phyros.ReferenceArchitecture.Engines
{
	public interface IWeatherForecastCalculator
	{
		IEnumerable<WeatherForecast> CalculateForecast(DateTime startDate, Temperature startingHigh, Temperature startingLow, int startingRelativeHumidity);
	}
}
