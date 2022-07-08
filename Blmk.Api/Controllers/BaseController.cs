using Blmk.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blmk.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected ActionResult HandleResult<TResult>(ResponseModel<TResult> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccessful && result.Data != null)
                return Ok(result);
            if (result.IsSuccessful && result.Data == null)
                return NotFound();

            return BadRequest(result.Message);
        }
        protected ActionResult HandleResult(ResponseModel result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccessful)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
