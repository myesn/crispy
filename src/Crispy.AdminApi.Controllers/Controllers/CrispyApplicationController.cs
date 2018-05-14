namespace Crispy.AdminApi.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("application")]
    public class CrispyApplicationController : Controller
    {
        public CrispyApplicationController(ICrispyApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }
        protected ICrispyApplicationService ApplicationService { get; set; }

        [HttpGet("page")]
        public async Task<IActionResult> PageAsync([NotNull, FromQuery]CryspyPageContext context) =>
            Ok(await ApplicationService.PageAsync(context));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([NotNull, FromBody]CrispyApplicationCreationContext context)
        {
            await ApplicationService.CreateAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyApplicationUpdateContext context)
        {
            await ApplicationService.UpdateAsync(context);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync([NotNull, FromRoute]Guid id) =>
            Ok(await ApplicationService.GetInfoAsync(id));

        [HttpPatch("{id}/includeglobalconfig/{include}")]
        public async Task<IActionResult> IncludeGlobalConfigAsync([NotNull, FromRoute]Guid id, [FromRoute]bool include)
        {
            await ApplicationService.IncludeGlobalConfigAsync(id, include);

            return Ok();
        }

        [HttpPatch("{id}/encryption/{encryption}")]
        public async Task<IActionResult> EncryptAsync([NotNull,FromRoute]Guid id, [FromRoute]bool encryption)
        {
            await ApplicationService.EncryptAsync(id, encryption);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [FromRoute]bool enabler)
        {
            await ApplicationService.EnableAsync(id, enabler);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([NotNull, FromRoute]Guid id)
        {
            await ApplicationService.DeleteAsync(id);

            return Ok();
        }

    }
}
