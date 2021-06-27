using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Phyros.ReferenceArchitecture.Composition
{
	public class JsonFormatterConfig
	{
		public static void ConfigureDefaultJsonFormatting(List<JsonConverter> converters)
		{
			JsonConvert.DefaultSettings = () => ConfigureSerializerSettings(new JsonSerializerSettings(), converters);
		}

		public static void ConfigureJsonFormatting(JsonSerializerSettings settings, List<JsonConverter> converters)
		{
			ConfigureSerializerSettings(settings, converters);
		}

		private static JsonSerializerSettings ConfigureSerializerSettings(JsonSerializerSettings settings, List<JsonConverter> converters)
		{
			settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
			settings.Formatting = Formatting.Indented;
			//TODO: SWAGGER UI BREAKS WITH TypeNameHandling SET TO Auto OR All!!!!
			//settings.TypeNameHandling = TypeNameHandling.Auto;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			settings.Converters.Add(new StringEnumConverter());
			foreach (var converter in converters)
			{
				settings.Converters.Add(converter);
			}

			return settings;
		}
	}
}
