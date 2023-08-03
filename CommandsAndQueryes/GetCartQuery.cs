using System;
using CartService.Models;
using MediatR;

namespace CartService.CommandsAndQueryes
{
    // Запрос на получение корзины по идентификатору пользователя
    public class GetCartQuery : IRequest<Cart>
    {
        public Guid UserId { get; set; }
    }
}