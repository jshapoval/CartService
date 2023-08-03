using System.Threading;
using System.Threading.Tasks;
using CartService.CommandsAndQueryes;
using CartService.Interfaces;
using CartService.Models;
using MediatR;

namespace CartService.Handlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartAsync(request.UserId);
        }
    }
}