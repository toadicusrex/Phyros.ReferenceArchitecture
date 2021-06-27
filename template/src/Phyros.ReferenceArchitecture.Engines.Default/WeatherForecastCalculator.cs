using System;
using System.Collections.Generic;
using Phyros.ReferenceArchitecture.DomainModels;

namespace Phyros.ReferenceArchitecture.Engines.Default
{
	public class WeatherForecastCalculator : IWeatherForecastCalculator
	{
		private static readonly Random Randomizer = new Random();
		private const int MaximumTemperatureDailyDrift = 5;
		private const int MaximumDailyHumidityDrift = 20;


		public IEnumerable<WeatherForecast> CalculateForecast(DateTime startDate, Temperature startingHigh, Temperature startingLow, int startingRelativeHumidity)
		{
			var forecastedWeatherDays = new List<WeatherForecast>();
			var high = startingHigh;
			var low = startingLow;
			var relativeHumidity = startingRelativeHumidity;

			for (var i = 0; i < 14; i++)
			{
				high.AddCelsius(GenerateTemperatureChangeInCelsius());
				low.AddCelsius(GenerateTemperatureChangeInCelsius());
				while (low.AsCelsius >= high.AsCelsius)
				{
					low.AddCelsius(GenerateTemperatureChangeInCelsius());
				}
				relativeHumidity += GenerateHumidityChange();
				if (relativeHumidity > 100)
				{
					relativeHumidity = 100;
				}

				if (relativeHumidity < 0)
				{
					relativeHumidity = 0;
				}
				var precipitationChance = CalculatePrecipitationChance(relativeHumidity);
				var precipitationKind = CalculatePrecipitationKind(precipitationChance, high, low);

				forecastedWeatherDays.Add(new WeatherForecast()
				{
					Date = startDate.AddDays(i).Date,
					High = high,
					Low = low,
					PrecipitationChance = precipitationChance,
					PrecipitationKind = precipitationKind,
					RelativeHumidity = relativeHumidity
				});
			}

			return forecastedWeatherDays;
		}

		internal string CalculatePrecipitationKind(in int precipitationChance, in Temperature high, in Temperature low)
		{
			string prefix = null;
			switch (precipitationChance)
			{
				case 0:
					return null;
				case int c when (c > 40 && c <= 70):
					{
						prefix = "Light ";
					}
					break;
				case int c when (c > 70 && c <= 99):
					{
						prefix = "Heavy ";
					}
					break;
				case int c when (c == 100):
					{
						prefix = "Apocalyptic ";
					}
					break;
			}

			string kind = null;
			if (low.AsCelsius < 0 && high.AsCelsius < 5M)
			{
				kind = "Snow";
			}
			else if (high.AsCelsius > 54.4M)
			{
				kind = "Moisture Condensing From Melting Bodies";
			}
			else if (low.AsCelsius < 0 && high.AsCelsius > 5M)
			{
				kind = "Freezing Rain";
			}
			else
			{
				kind = "Rain";
			}
			return $"{prefix}{kind}";
		}

		internal int CalculatePrecipitationChance(in int relativeHumidity)
		{
			switch (relativeHumidity)
			{
				case int h when (h >= 0 && h <= 50):
					{
						// if the relative humidity is < 50, there's just not going to be a chance of precipitation.
						return 0;
					}
				case int h when (h > 50 && h <= 60):
					{
						// if the relative humidity is between 50 and 60, we'll say it's 5% chance.
						return 5;
					}
				case int h when (h > 60 && h <= 70):
					{
						// if the relative humidity is between 60 and 70, we'll say it's 10% chance.
						return 10;
					}
				case int h when (h > 70 && h <= 80):
					{
						// if the relative humidity is between 70 and 80, we'll say it's 15% chance.
						return 15;
					}
				case int h when (h > 70 && h <= 80):
					{
						// if the relative humidity is between 70 and 80, we'll say it's 15% chance.
						return 15;
					}
				case int h when (h > 80 && h <= 96):
					{
						// here's where we get crazy.  For each point of relative humidity between 81 and 96, we're going to multiply that by 5, so 81% humidity = 20% chance of
						// precipitation, 82% humidity = 25% chance of precipitation, etc.  We'll stop at 96. 
						return ((relativeHumidity - 81) * 5) + 20;
					}
				case int h when (h > 96 && h <= 100):
					{
						// if relative humidity is greater than 96%, it's going to precipitate. 
						return 100;
					}
				default:
					throw new Exception($"Invalid precipitation chance ({relativeHumidity}); can only be between 0% and 100%.");
			}
		}

		internal int GenerateHumidityChange()
		{
			return
				Randomizer.Next(0, MaximumDailyHumidityDrift) * (Randomizer.Next(2) == 1 ? 1 : -1);
		}

		internal decimal GenerateTemperatureChangeInCelsius()
		{
			return
				(Randomizer.Next(0, MaximumTemperatureDailyDrift * 10) / 10M)
				* (Randomizer.Next(2) == 1 ? 1 : -1);
		}
	}
}
