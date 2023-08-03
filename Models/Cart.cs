using System;
using System.Collections.Generic;

namespace CartService.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public uint ItemsCount { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItem> Items { get; set; }
    }
}