namespace Crispy.Apis.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("project")]
    public class CrispyProjectController : Controller
    {
        public CrispyProjectController(ICrispyProjectService projectService)
        {
            ProjectService = projectService;
        }
        protected ICrispyProjectService ProjectService { get; set; }

        [HttpGet("page")]
        public async Task<IActionResult> PageAsync([NotNull, FromQuery]CryspyPageContext context) =>
            Ok(await ProjectService.PageAsync(context));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([NotNull, FromBody]CrispyProjectCreationContext context)
        {
            await ProjectService.CreateAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyProjectUpdateContext context)
        {
            await ProjectService.UpdateAsync(context);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync([NotNull, FromRoute]Guid id) =>
            Ok(await ProjectService.GetInfoAsync(id));

        [HttpPatch("{id}/includeglobalconfig/{include}")]
        public async Task<IActionResult> IncludeGlobalConfigAsync([NotNull, FromRoute]Guid id, [NotNull, FromRoute]bool include)
        {
            await ProjectService.IncludeGlobalConfigAsync(id, include);

            return Ok();
        }

        [HttpPatch("{id}/encryption/{encryption}")]
        public async Task<IActionResult> EncryptAsync(Guid id, bool encryption)
        {
            await ProjectService.EncryptAsync(id, encryption);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [NotNull, FromRoute]bool enabler)
        {
            await ProjectService.EnableAsync(id, enabler);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([NotNull, FromRoute]Guid id)
        {
            await ProjectService.DeleteAsync(id);

            return Ok();
        }

    }
}
