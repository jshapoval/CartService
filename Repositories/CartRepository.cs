using System;
using System.Threading.Tasks;
using CartService.Interfaces;
using CartService.Models;

namespace CartService.Repositories
{
    public class CartRepository : ICartRepository
    {
        Task<Cart> ICartRepository.GetCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task ICartRepository.RemoveCartItemAsync(Guid cartId, Guid productId)
        {
            throw new NotImplementedException();
        }

        Task ICartRepository.UpdateCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}