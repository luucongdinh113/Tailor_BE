using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IMediator _mediator;

        public TaskController(IJWTService jWTService, IMediator mediator)
        {
            _jWTService = jWTService;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(DeleteTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [AllowAnonymous]
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }
    }
}
