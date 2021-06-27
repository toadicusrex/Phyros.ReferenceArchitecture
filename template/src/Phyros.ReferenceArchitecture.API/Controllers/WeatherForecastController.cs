using System.Collections.Generic;
using Phyros.ReferenceArchitecture.DTO;
using Phyros.ReferenceArchitecture.Managers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Phyros.ReferenceArchitecture.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IWeatherForecastManager _forecastManager;
		private readonly IMapper _mapper;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastManager forecastManager, IMapper mapper)
		{
			_logger = logger;
			_forecastManager = forecastManager;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<WeatherForecastDTO> Get()
		{
			var currentForecast = _forecastManager.GetForecast();
			return _mapper.Map<IEnumerable<WeatherForecastDTO>>(currentForecast);
		}
	}
}
