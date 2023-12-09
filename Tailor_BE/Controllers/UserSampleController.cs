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
    [Authorize]
    public class UserSampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserSampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUserSample")]
        public async Task<IActionResult> CreateUCreateUserSampleser(CreateUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteUserSample")]
        public async Task<IActionResult> DeleteUserSample(DeleteUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpPut("UpdateUserSample")]
        public async Task<IActionResult> UpdateUserSample(UpdateUserSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetUserSampleByUserQuery")]
        public async Task<IActionResult> GetUserSampleByUserQuery(Guid userId,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserSampleByUserQuery() { UserId=userId }, cancellationToken));
        }
    }
}
