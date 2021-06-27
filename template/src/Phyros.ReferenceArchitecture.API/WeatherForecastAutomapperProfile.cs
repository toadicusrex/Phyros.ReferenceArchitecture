using Phyros.ReferenceArchitecture.DTO;
using AutoMapper;

namespace Phyros.ReferenceArchitecture.API
{
	public class WeatherForecastAutomapperProfile : Profile
	{
		public WeatherForecastAutomapperProfile()
		{
			CreateMap<DomainModels.WeatherForecast, WeatherForecastDTO>()
				.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
				.ForMember(dest => dest.HighCelsius, opt => opt.MapFrom(src => src.High.AsCelsius))
				.ForMember(dest => dest.HighFahrenheit, opt => opt.MapFrom(src => src.High.AsFahrenheit))
				.ForMember(dest => dest.LowCelsius, opt => opt.MapFrom(src => src.Low.AsCelsius))
				.ForMember(dest => dest.LowFahrenheit, opt => opt.MapFrom(src => src.Low.AsFahrenheit))
				.ForMember(dest => dest.RelativeHumidityPercentage, opt => opt.MapFrom(src => src.RelativeHumidity))
				.ForMember(dest => dest.PrecipitationChancePercentage, opt => opt.MapFrom(src => src.PrecipitationChance))
				.ForMember(dest => dest.PrecipitationKind, opt => opt.MapFrom(src => src.PrecipitationKind))
				;
		}
	}
}
