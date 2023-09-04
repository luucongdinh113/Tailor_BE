using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Dtos;
using Tailor_Business.Queries.Chat;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IActionResult> GeTChatByUserId(Guid uerId,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetChatByUserQuery()
            { UserId=uerId},cancellationToken));
        }
    }
}
