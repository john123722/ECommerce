using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class CartModel
    {
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public int BuyerId { get; set; }
        public int BuyerQuantity { get; set; }
    }
}