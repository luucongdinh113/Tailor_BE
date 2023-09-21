﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tailor_Business.Commands.User;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotifyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateNotify")]
        public async Task<IActionResult> CreateNotify(CreateNotifyCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpDelete("DeleteNotify")]
        public async Task<IActionResult> DeleteNotify(DeleteNotifyCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }

        [HttpPut("UpdateNotify")]
        public async Task<IActionResult> UpdateNotify(UpdateNotifyCommand request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(request, cancellation));
        }
    }
}
