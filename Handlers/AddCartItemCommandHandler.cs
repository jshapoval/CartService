using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CartService.Interfaces;
using CartService.Models;
using MediatR;

namespace CartService.Handlers
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        //public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        public async Task<bool> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            // Получаем корзину из хранилища по идентификатору пользователя
            var cart = await _cartRepository.GetCartAsync(request.CartId);

            if (cart == null)
            {
                // Если корзины для пользователя еще не существует, создаем новую корзину
                cart = new Cart
                {
                    Id = request.CartId,
                    UserId = request.CartId
                };
            }

            // Проверяем, есть ли уже такой товар в корзине
            var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == request.ProductId);
            if (existingItem != null)
            {
                // Если товар уже есть в корзине, обновляем количество и общую стоимость
                existingItem.Quantity += request.Quantity;
                existingItem.TotalAmount = existingItem.Quantity * existingItem.Price;
            }
            else
            {
                // Если товара нет в корзине, добавляем его
                var newItem = new CartItem
                {
                    CartId = request.CartId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Price = request.Price,
                    TotalAmount = request.Quantity * request.Price
                };
                cart.Items.Add(newItem);
            }

            // Обновляем корзину в хранилище
            await _cartRepository.UpdateCartAsync(cart);

            //return Unit.Value;
            return true;
        }
    }
}