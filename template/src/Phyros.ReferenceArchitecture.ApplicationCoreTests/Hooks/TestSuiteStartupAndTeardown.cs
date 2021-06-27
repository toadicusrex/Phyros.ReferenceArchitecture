using Newtonsoft.Json;
using Phyros.ReferenceArchitecture.Composition;
using TechTalk.SpecFlow;

namespace Phyros.ReferenceArchitecture.ApplicationCoreTests.Hooks
{
	public class TestSuiteStartupAndTeardown
	{
		
		[BeforeTestRun]
		public static void Initialize()
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			ApplicationComposition.Container.Options.AllowOverridingRegistrations = true;
			
			ApplicationComposition.Compose(new System.Collections.Generic.List<System.Type>());
			
		}

		[AfterTestRun]
		public static void Cleanup()
		{
		}
	}
}
