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
    [Authorize(Policy = "AdminOnly")]
    public class InventoryCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryCategoryController(IJWTService jWTService, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateInventoryCategory")]
        public async Task<IActionResult> CreateInventoryCategory(CreateInventoryCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteInventoryCategory")]
        public async Task<IActionResult> DeleteInventoryCategory(DeleteInventoryCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpPut("UpdateInventoryCategory")]
        public async Task<IActionResult> UpdateInventoryCategory(UpdateInventoryCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetAllInventoryCategory")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllInventoryCategoryQuery(), cancellationToken));
        }

        [HttpGet("GetByIdInventory/{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetInventoryCategoryByIdQuery() { Id = id }, cancellationToken));
        }
    }
}
