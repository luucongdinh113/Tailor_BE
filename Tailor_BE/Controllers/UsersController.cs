using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost(nameof(Auth))]
        public IActionResult Auth([FromBody] UserModel data)
        {
            return Ok(_jWTService.GenerateJSONWebToken(data));
        }
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<IActionResult> Create(CreateChatCommand command, CancellationToken cancellation)
        //{
        //    return Ok(await _mediator.Send(command, cancellation));
        //}

    }
}
