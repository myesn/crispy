namespace Crispy.AdminApi.Controllers
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    [Route("keyvaluepair")]
    [ApiController]
    public class CrispyKeyValuePairController : ControllerBase
    {
        public CrispyKeyValuePairController(ICrispyKeyValuePairService keyValuePairService)
        {
            KeyValuePairService = keyValuePairService;
        }
        protected ICrispyKeyValuePairService KeyValuePairService { get; }

        [HttpGet("{enviromentId}")]
        public async Task<IActionResult> GetAllAsync([FromRoute]Guid? enviromentId) =>
            Ok(await KeyValuePairService.GetAllAsync(enviromentId));

        [HttpGet("{id}/histories")]
        public async Task<IActionResult> GetHistoiesAsync([NotNull, FromRoute]Guid id) =>
            Ok(await KeyValuePairService.GetHistoiesAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddAsync([NotNull, FromBody]CrispyKeyValuePairAddtionContext context)
        {
            await KeyValuePairService.AddAsync(context);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([NotNull, FromBody]CrispyKeyValuePairUpdateContext context)
        {
            await KeyValuePairService.UpdateAsync(context);

            return Ok();
        }

        [HttpPatch("{id}/enabler/{enabler}")]
        public async Task<IActionResult> EnableAsync([NotNull, FromRoute]Guid id, [FromRoute]bool enabler)
        {
            await KeyValuePairService.EnableAsync(id, enabler);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([NotNull, FromRoute]Guid id)
        {
            await KeyValuePairService.DeleteAsync(id);

            return Ok();
        }
    }
}
