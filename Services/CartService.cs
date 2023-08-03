using System;
using System.Threading.Tasks;
using CartService.CommandsAndQueryes;
using CartService.Interfaces;
using CartService.Models;
using MediatR;

namespace CartService.Services
{
    public class CartService : ICartService
    {
        private readonly IMediator _mediator;

        public CartService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task AddCartItemAsync(AddCartItemCommand command)
        {
            // Отправляем команду на добавление товара в корзину через MediatR
            await _mediator.Send(command);
        }

        public async Task RemoveCartItemAsync(RemoveCartItemCommand command)
        {
            // Отправляем команду на удаление товара из корзины через MediatR
            await _mediator.Send(command);
        }

        public async Task<Cart> GetCartAsync(Guid userId)
        {
            // Создаем запрос на получение корзины через MediatR
            var query = new GetCartQuery { UserId = userId };

            // Отправляем запрос и получаем результат
            return await _mediator.Send(query);
        }
    }
}