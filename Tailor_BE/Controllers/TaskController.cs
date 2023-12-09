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
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateTaskCommand request, CancellationToken cancellation)
        {
            try
            {
                return Ok(await _mediator.Send(request, cancellation));
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return BadRequest(new { message = "Error processing the request." });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(DeleteTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateTasksIndex")]
        public async Task<IActionResult> UpdateTasksIndex(UpdateTaskIndexCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetTasksQuery(), cancellation));
        }

        [HttpGet("GetTaskByIdQuery")]
        public async Task<IActionResult> GetTaskByIdQuery(int id,CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetTaskByIdQuery() { Id=id}, cancellation));
        }

        [HttpGet("GetTasksByUserIdQuery")]
        public async Task<IActionResult> GetTasksByUserIdQuery(Guid userId, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetTasksByUserIdQuery() { UserId = userId }, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateInfoTask")]
        public async Task<IActionResult> UpdateInfoTask(UpdateInfoTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateInfoTask1")]
        public async Task<IActionResult> UpdateInfoTask1(UpdateInfoTask1Command request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateStatusTask")]
        public async Task<IActionResult> UpdateStatusTask(UpdateStatusTaskCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }
    }
}
