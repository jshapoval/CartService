using System;
using MediatR;

namespace CartService
{
    // Команда на удаление товара из корзины
    public class RemoveCartItemCommand : IRequest<bool>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}