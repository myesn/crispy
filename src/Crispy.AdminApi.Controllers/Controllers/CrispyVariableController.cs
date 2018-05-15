namespace Crispy.AdminApi.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("variable")]
    public class CrispyVariableController : Controller
    {
        public CrispyVariableController(ICrispyVariableService variableService)
        {
            VariableService = variableService;
        }
        protected ICrispyVariableService VariableService { get; }

        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetInfoAsync([FromRoute]Guid? applicationId) =>
            Ok(await VariableService.GetAllAsync(applicationId));

        [HttpPost]
        public async Task<IActionResult> AddAsync([NotNull, FromBody]CrispyVariableAddtionContext context)
        {
            await VariableService.AddAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyVariableUpdateContext context)
        {
            await VariableService.UpdateAsync(context);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [FromRoute]bool enabler)
        {
            await VariableService.EnableAsync(id, enabler);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([NotNull, FromRoute]Guid id)
        {
            await VariableService.DeleteAsync(id);

            return Ok();
        }
    }
}