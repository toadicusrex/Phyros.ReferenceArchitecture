using System;
using System.Collections.Generic;
using Phyros.ReferenceArchitecture.Engines;
using Phyros.ReferenceArchitecture.Engines.Default;
using Phyros.ReferenceArchitecture.Infrastructure;
using Phyros.ReferenceArchitecture.Infrastructure.SatelliteConnectivity;
using Phyros.ReferenceArchitecture.Managers;
using Phyros.ReferenceArchitecture.Managers.Default;
using Newtonsoft.Json;
using Phyros.ReferenceArchitecture.ServiceDiagnostics;
using SimpleInjector;

namespace Phyros.ReferenceArchitecture.Composition
{
	public static class ApplicationComposition
	{
		public static readonly Container Container = new Container();
		
		public static void Compose(List<Type> automapperProfiles)
		{
			JsonFormatterConfig.ConfigureDefaultJsonFormatting(new List<JsonConverter>());
			Container.ConfigureAutomapper(automapperProfiles);
			Container.Register<IWeatherForecastManager, WeatherForecastManager>();
			Container.Register<IWeatherForecastCalculator, WeatherForecastCalculator>();
			Container.Register<IWeatherDataRepository, SatelliteWeatherDataRepository>();

			// diagnostics providers
			Container.Collection.Register<IServiceDiagnosticsProvider>(AppDomain.CurrentDomain.GetAssemblies());
		}
	}
}
