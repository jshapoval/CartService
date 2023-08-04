using System;
using System.Threading.Tasks;
using CartService.Models;
using CartService.Resources;

namespace CartService.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(Guid userId);
        Task UpdateCartAsync(Cart cart);
        Task<OperationResponse<bool>> RemoveCartItemAsync(Guid cartId, Guid productId);
    }
}