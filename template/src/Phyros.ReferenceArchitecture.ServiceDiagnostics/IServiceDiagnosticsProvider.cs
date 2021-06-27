using System.Collections.Generic;

namespace Phyros.ReferenceArchitecture.ServiceDiagnostics
{
	public interface IServiceDiagnosticsProvider
	{
		IEnumerable<SystemDiagnosticsInformation> PerformSystemTest();
	}
}
