using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class BuyModel
    {
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public int BuyerId { get; set; }
        public int BuyerQuantity { get; set; }
        public string PricePerUnit { get; set; }
        public string TotalPrice { get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get;set; }
        public int OrderCleared { get; set; }
    }
}