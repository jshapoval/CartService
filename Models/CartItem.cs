using System;

namespace CartService.Models
{
    public class CartItem
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
    }
}