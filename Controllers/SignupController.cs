using AppInsightsTelemetryDemo.Models;
using AppInsightsTelemetryDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppInsightsTelemetryDemo.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignupController : ControllerBase
    {
        private ISignupService _signupService;

        public SignupController(ISignupService signupService)
        {
            _signupService = signupService;
        }

        [HttpPost]
        public IActionResult NewSignup([FromBody]NewSignupRequest request)
        {
            _signupService.ProcessRequest(request);
            return Ok();
        }
    }
}
