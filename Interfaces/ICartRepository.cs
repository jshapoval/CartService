using System;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(Guid userId);
        Task UpdateCartAsync(Cart cart);
        Task RemoveCartItemAsync(Guid cartId, Guid productId);
    }
}