using System;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.Interfaces
{
    public interface ICartService
    {
        Task AddCartItemAsync(AddCartItemCommand command);
        Task RemoveCartItemAsync(RemoveCartItemCommand command);
        Task<Cart> GetCartAsync(Guid userId);
    }
}
