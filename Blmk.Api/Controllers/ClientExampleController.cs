using Blmk.Application.Features.Client.Commands;
using Blmk.Application.Features.Client.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Blmk.Api.Controllers
{
    public class ClientExampleController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddClient(CreateClientCommand request)
        {
            return HandleResult(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return HandleResult(await Mediator.Send(new GetAllClientsQuery()));
        }
    }
}
