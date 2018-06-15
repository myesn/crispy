namespace Crispy.AdminApi.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("environment")]
    [ApiController]
    public class CrispyEnvironmentController : ControllerBase
    {
        public CrispyEnvironmentController(ICrispyEnviromentService enviromentService)
        {
            EnviromentService = enviromentService;
        }
        protected ICrispyEnviromentService EnviromentService { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync([NotNull, FromRoute]Guid id) =>
            Ok(await EnviromentService.GetInfoAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddAsync([NotNull,FromBody]CrispyEnvironmentAddtionContext context)
        {
            await EnviromentService.AddAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyEnvironmentUpdateContext context)
        {
            await EnviromentService.UpdateAsync(context);

            return Ok();
        }

        [HttpPatch("{id}/includeglobalconfig/{include}")]
        public async Task<IActionResult> IncludeGlobalConfigAsync([NotNull, FromRoute]Guid id, [FromRoute]bool include)
        {
            await EnviromentService.IncludeGlobalConfigAsync(id, include);

            return Ok();
        }

        [HttpPatch("{id}/encryption/{encryption}")]
        public async Task<IActionResult> EncryptAsync([NotNull, FromRoute]Guid id, [FromRoute]bool encryption)
        {
            await EnviromentService.EncryptAsync(id, encryption);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [FromRoute]bool enabler)
        {
            await EnviromentService.EnableAsync(id, enabler);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([NotNull, FromRoute]Guid id)
        {
            await EnviromentService.DeleteAsync(id);

            return Ok();
        }
    }
}
