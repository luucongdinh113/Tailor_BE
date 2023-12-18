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
    public class SampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("CreateSample")]
        public async Task<IActionResult> CreateSample(CreateSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("DeleteSample")]
        public async Task<IActionResult> DeleteSample(DeleteSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateSample")]
        public async Task<IActionResult> UpdateSample(UpdateSampleCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetSamplesByUser")]
        public async Task<IActionResult> GetSamplesByUser(Guid userId, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetSamplesByUserQuery() { UserId = userId }, cancellation));
        }

        [AllowAnonymous]
        [HttpGet("GetSamples")]
        public async Task<IActionResult> GetSamples(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetSamplesQuery(), cancellation));
        }

        [AllowAnonymous]
        [HttpGet("GetSample")]
        public async Task<IActionResult> GetSample(int id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetSampleQuery() { Id=id}, cancellation));
        }
    }
}
