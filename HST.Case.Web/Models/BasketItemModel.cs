﻿namespace HST.Case.Web.Models
{
    public class BasketItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
