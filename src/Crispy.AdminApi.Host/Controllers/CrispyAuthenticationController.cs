namespace Crispy.AdminApi.Controllers
{
    using Crispy.AdminApi.Host;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Route("authentication")]
    public class CrispyAuthenticationController : Controller
    {
        public CrispyAuthenticationController(IOptionsSnapshot<AdminApiOptions> options)
        {
            Options = options.Value;
        }

        protected AdminApiOptions Options { get; }

        [HttpPost]
        public IActionResult Authenticate([FromBody]string password)
        {
            if (password != Options.Password)
                throw new UnauthorizedAccessException();

            return Ok(Options.Password);
        }
    }
}
