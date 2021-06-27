using System.Collections.Generic;
using Phyros.ReferenceArchitecture.DomainModels;

namespace Phyros.ReferenceArchitecture.Managers
{
	public interface IWeatherForecastManager
	{
		IEnumerable<WeatherForecast> GetForecast();
	}
}
