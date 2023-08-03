using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CartService.CommandsAndQueryes;
using MediatR;

namespace CartService.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/cart/add")]
        public async Task<IActionResult> AddToCart([FromBody] AddCartItemCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("api/cart/remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveCartItemCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("api/cart/{userId}")]
        public async Task<IActionResult> GetCart(Guid userId)
        {
            var query = new GetCartQuery { UserId = userId };
            var cart = await _mediator.Send(query);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }
    }
}