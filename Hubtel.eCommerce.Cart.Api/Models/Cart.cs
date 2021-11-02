using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    //[Keyless]
    public class Cart
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public DateTime? Time { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string PhoneNumber { get; set; }
    }
}
