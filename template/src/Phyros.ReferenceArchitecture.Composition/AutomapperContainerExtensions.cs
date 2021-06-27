using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;

namespace Phyros.ReferenceArchitecture.Composition
{
	internal static class AutomapperContainerExtensions
	{
		public static Container ConfigureAutomapper(this Container container, List<Type> automapperProfiles)
		{
			var mappingExpression = new MapperConfigurationExpression();
			automapperProfiles.ForEach(profile => mappingExpression.AddProfile(profile));

			var config = new MapperConfiguration(mappingExpression);
			container.RegisterInstance(config);
			container.RegisterInstance(config.CreateMapper());
			return container;
		}
	}
}
