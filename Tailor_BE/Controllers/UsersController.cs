using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Business.Queries.User;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IMediator _mediator;

        public UsersController(IJWTService jWTService, IMediator mediator)
        {
            _jWTService = jWTService;
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet(nameof(Auth))]
        public async Task<IActionResult> Auth(string userName, string pwd)
        {
            return Ok(await _jWTService.GenerateJSONWebToken(new UserModel() { UserName=userName, PassWord=pwd}));
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(), cancellationToken));
        }

        [Authorize()]
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = id }, cancellationToken));
        }

        [HttpGet("CheckOTP")]
        public async Task<IActionResult> CheckOTP(string oTP, string userName, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new CheckOTPQuery() { OTP=oTP,UserName=userName}, cancellationToken));
        }

        [HttpPut("SendOTPToMail")]
        public async Task<IActionResult> SendOTPToMail(SendOTPToMailCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPwdCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [Authorize]
        [HttpPut("UpdatePasswordForUser")]
        public async Task<IActionResult> UpdatePasswordForUser(UpdatePasswordForUserCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
