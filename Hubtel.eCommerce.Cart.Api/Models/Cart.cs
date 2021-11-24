using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    //[Keyless]
    public class Cart
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime? Time { get; set; }

        public string PhoneNumber { get; set; }
    }
}
