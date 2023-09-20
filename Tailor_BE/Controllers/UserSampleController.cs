using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Business.Queries.ProductCategory;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSampleController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IMediator _mediator;

        public UserSampleController(IJWTService jWTService, IMediator mediator)
        {
            _jWTService = jWTService;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("CreateUserSample")]
        public async Task<IActionResult> CreateUCreateUserSampleser(CreateUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpDelete("DeleteUserSample")]
        public async Task<IActionResult> DeleteUserSample(DeleteUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpPut("UpdateUserSample")]
        public async Task<IActionResult> UpdateUserSample(UpdateUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetAllUserSample")]
        public async Task<IActionResult> GetAllUserSample(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUserSampleQuery(), cancellationToken));
        }
    }
}
