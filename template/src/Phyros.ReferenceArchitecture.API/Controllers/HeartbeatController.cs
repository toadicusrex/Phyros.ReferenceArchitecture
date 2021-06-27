using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phyros.ReferenceArchitecture.ServiceDiagnostics;

namespace Phyros.ReferenceArchitecture.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
	    private readonly IEnumerable<IServiceDiagnosticsProvider> _diagnosticsProviders;
	    internal const string ActiveDeclaration = "Service is active.";

	    public HeartbeatController(IEnumerable<IServiceDiagnosticsProvider> diagnosticsProviders)
	    {
		    _diagnosticsProviders = diagnosticsProviders;
	    }

	    [HttpGet]
	    public string Get()
	    {
		    return ActiveDeclaration;
	    }

		[HttpGet, Route("healthcheck")]
		public List<SystemDiagnosticsInformation> HealthCheck()
		{
			return _diagnosticsProviders.SelectMany(x => x.PerformSystemTest()).ToList();
		}
	}
}