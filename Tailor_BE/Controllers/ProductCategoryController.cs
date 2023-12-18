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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductCategoryController(IJWTService jWTService, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateProductCategory")]
        public async Task<IActionResult> CreateProductCategory(CreateProductCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteProductCategory")]
        public async Task<IActionResult> DeleteProductCategory(DeleteProductCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpPut("UpdateProductCategory")]
        public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }


        [AllowAnonymous]
        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductCategoryQuery(), cancellationToken));
        }

        [AllowAnonymous]
        [HttpGet("GetByIdProductCategory/{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetProductCategoryByIdQuery() { Id = id }, cancellationToken));
        }
    }
}
