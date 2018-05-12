namespace Crispy.Apis.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("enviroment")]
    public class CrispyEnviromentController : Controller
    {
        public CrispyEnviromentController(ICrispyEnviromentService enviromentService)
        {
            EnviromentService = enviromentService;
        }
        protected ICrispyEnviromentService EnviromentService { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync([NotNull, FromRoute]Guid id) =>
            Ok(await EnviromentService.GetInfoAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddAsync([NotNull,FromBody]CrispyEnviromentAddtionContext context)
        {
            await EnviromentService.AddAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyEnviromentUpdateContext context)
        {
            await EnviromentService.UpdateAsync(context);

            return Ok();
        }

        [HttpPatch("{id}/includeglobalconfig/{include}")]
        public async Task<IActionResult> IncludeGlobalConfigAsync([NotNull, FromRoute]Guid id, [NotNull, FromRoute]bool include)
        {
            await EnviromentService.IncludeGlobalConfigAsync(id, include);

            return Ok();
        }

        [HttpPatch("{id}/encryption/{encryption}")]
        public async Task<IActionResult> EncryptAsync(Guid id, bool encryption)
        {
            await EnviromentService.EncryptAsync(id, encryption);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [NotNull, FromRoute]bool enabler)
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
