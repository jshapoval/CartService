using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CartService.Interfaces;
using CartService.Models;
using CartService.Resources;

namespace CartService.Repositories
{
    //логика обработки в БД
    public class CartRepository : ICartRepository
    {
        private readonly ApiContext ApiContext;

        public CartRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }
        public async Task<Cart> GetCartAsync(Guid userId)
        {
            return await ApiContext.Carts
                .SingleOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<OperationResponse<bool>> RemoveCartItemAsync(Guid cartId, Guid productId)
        {
            var cart = await ApiContext.Carts
                .Include(i => i.Items)
                .SingleOrDefaultAsync(c => c.Id == cartId);

            if (cart is null)
            {
                return new OperationResponse<bool>(OperationResponse.ErrorCodes.Cart_NotFound);
            }

            var item = cart.Items.SingleOrDefault(i => i.ProductId == productId);

            if (item is null)
            {
                return new OperationResponse<bool>(OperationResponse.ErrorCodes.CartItem_NotFound);
            }

            cart.Items.Remove(item);

            // изменить кол-во

            await ApiContext.SaveChangesAsync();

            return new OperationResponse<bool>(true);
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            //или обновить?
            ApiContext.Add<Cart>(cart);
            ApiContext.SaveChanges();
        }
    }
}