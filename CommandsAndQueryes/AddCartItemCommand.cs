using MediatR;
using System;

namespace CartService
{
    // Команда на добавление товара в корзину
    public class AddCartItemCommand : IRequest<bool>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}