using System;
using System.Collections.Generic;
using System.Linq;
using Phyros.ReferenceArchitecture.Infrastructure.ReferenceModels;
using Phyros.ReferenceArchitecture.ServiceDiagnostics;

namespace Phyros.ReferenceArchitecture.Infrastructure.SatelliteConnectivity
{
	public class SatelliteWeatherDataRepository : IWeatherDataRepository, IServiceDiagnosticsProvider
	{
		/// <summary>
		/// Gets two weeks worth of fake satellite data.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IEnumerable<WeatherRecord> GetSatelliteData(DateTime periodEndDate)
		{
			//  If this were a real repository, we'd make a connection to an API and pull this data down.  As it is, we're going to kind of fake a trend.

			var listOfResults = new List<WeatherRecord>();
			for (var i = -14; i < 0; i++)
			{
				if (listOfResults.Any())
				{
					var newHigh = listOfResults.Last().HighInCelsius + GenerateTemperatureChange();
					var newLow = listOfResults.Last().LowInCelsius + GenerateTemperatureChange();
					while (newLow >= newHigh)
					{
						// just verify the low can't be higher than the high.  We'll subtract using the same random calculation, but then divide it by 2 so it isn't a huge shift.
						newLow -= ((Randomizer.Next(0, MaximumTemperatureDailyDrift * 10) / 10M)/2);
					}
					var newHumidity = listOfResults.Last().RelativeHumidity + GenerateHumidityChange();
					if (newHumidity < 0)
					{
						newHumidity = 0;
					}
					else if (newHumidity > 100)
					{
						newHumidity = 100;
					}
					listOfResults.Add(new WeatherRecord()
					{
						Date = periodEndDate.AddDays(i).Date,
						HighInCelsius = newHigh,
						LowInCelsius = newLow,
						RelativeHumidity = newHumidity
					});
				}
				else
				{
					listOfResults.Add(new WeatherRecord()
					{
						Date = periodEndDate.AddDays(i).Date,
						HighInCelsius = AverageFakeTemperaturePerMonth[periodEndDate.Month - 1] + 5 + GenerateTemperatureChange(),
						LowInCelsius = AverageFakeTemperaturePerMonth[periodEndDate.Month - 1] - 5 + GenerateTemperatureChange(),
						RelativeHumidity = 60 + GenerateHumidityChange()
					});
				}
			}

			return listOfResults;
		}

		private int GenerateHumidityChange()
		{
			return 
				Randomizer.Next(0, MaximumDailyHumidityDrift) * (Randomizer.Next(2) == 1 ? 1 : -1);
		}

		private static readonly decimal[] AverageFakeTemperaturePerMonth = new[] {-6.1M, -1.1M, 5.5M, 12.7M, 20M, 26.1M, 34.4M, 31.1M, 23.3M, 15.5M, 6.1M, -1.6M};
		private const int MaximumTemperatureDailyDrift = 5;
		private const int MaximumDailyHumidityDrift = 20;
		private static readonly Random Randomizer = new Random();


		private decimal GenerateTemperatureChange()
		{
			return 
				(Randomizer.Next(0, MaximumTemperatureDailyDrift * 10) / 10M) 
				* (Randomizer.Next(2) == 1 ? 1 : -1);
		}

		public IEnumerable<SystemDiagnosticsInformation> PerformSystemTest()
		{
			return new List<SystemDiagnosticsInformation>()
			{
				new SystemDiagnosticsInformation()
				{
					Description = "Connection to Satellite",
					Successful = true,
					Message = "Successfully connected to the fake satellite."
				}
			};
		}
	}
}
