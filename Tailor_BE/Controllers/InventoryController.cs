using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Business.Queries.Product;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IMediator _mediator;

        public InventoryController(IJWTService jWTService, IMediator mediator)
        {
            _jWTService = jWTService;
            _mediator = mediator;
        }

        [HttpPost("CreateInventory")]
        public async Task<IActionResult> CreateInventory(CreateInventoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteInventory")]
        public async Task<IActionResult> DeleteInventory(DeleteInventoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpPut("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory(UpdateInventoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetAllInventory")]
        public async Task<IActionResult> GetAllInventory(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllInventoryQuery(), cancellationToken));
        }

        [HttpGet("GetInventory/{id}")]
        public async Task<IActionResult> GetInventory(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetInventoryByIdQuery() { Id = id }, cancellationToken));
        }
    }
}
