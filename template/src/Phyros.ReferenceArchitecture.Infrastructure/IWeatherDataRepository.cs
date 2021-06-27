using System;
using System.Collections.Generic;
using Phyros.ReferenceArchitecture.Infrastructure.ReferenceModels;

namespace Phyros.ReferenceArchitecture.Infrastructure
{
	public interface IWeatherDataRepository
	{
		/// <summary>
		/// Gets two weeks worth of satellite data.
		/// </summary>
		/// <returns></returns>
		IEnumerable<WeatherRecord> GetSatelliteData(DateTime rangeEndDate);
	}

	// ReSharper disable once InconsistentNaming
	public static class IWeatherDataRepositoryExtensions
	{
		public static IEnumerable<WeatherRecord> GetSatelliteData(this IWeatherDataRepository repository)
		{
			return repository.GetSatelliteData(DateTime.Now);
		}
	}
}
