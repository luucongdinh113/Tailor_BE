using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IMediator _mediator;

        public NotifyController(IJWTService jWTService, IMediator mediator)
        {
            _jWTService = jWTService;
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost(nameof(Auth))]
        public IActionResult Auth([FromBody] UserModel data)
        {
            return Ok(_jWTService.GenerateJSONWebToken(data));
        }

        [AllowAnonymous]
        [HttpPost("CreateNotify")]
        public async Task<IActionResult> CreateNotify(CreateUserCommand request,CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpDelete("DeleteNotify")]
        public async Task<IActionResult> DeleteNotify(DeleteUserCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpPut("UpdateNotify")]
        public async Task<IActionResult> UpdateNotify(UpdateUserCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }
    }
}
