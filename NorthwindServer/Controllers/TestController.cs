using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;

        public TestController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public string Get()
        {
            _loggerManager.LogInfo("Info");
            _loggerManager.LogDebug("Debug");
            _loggerManager.LogWarning("Warning");
            _loggerManager.LogError("Error");

            return "dfdfd";
        }
    }
}
