using System.Threading;
using System.Threading.Tasks;
using CartService.Interfaces;
using MediatR;

namespace CartService.Handlers
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.RemoveCartItemAsync(request.CartId, request.ProductId);
            return true;
        }
    }
}