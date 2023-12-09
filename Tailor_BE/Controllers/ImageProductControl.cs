using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.ImageProduct;
using Tailor_Business.Commands.User;
using Tailor_Business.Queries.ImageProduct;
using Tailor_Business.Queries.ProductCategory;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class ImageProductControl : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImageProductControl(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateImage")]
        public async Task<IActionResult> CreateImage(CreateImageCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteImage")]
        public async Task<IActionResult> DeleteImage(DeleteImageCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpGet("GetImagesByTaskId")]
        public async Task<IActionResult> GetImagesByTaskId(int productId,CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetImageByProductIdQuery() { ProductId= productId }, cancellation));
        }
    }
}
