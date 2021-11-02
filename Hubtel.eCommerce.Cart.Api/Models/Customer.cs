using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class Customer
    {
        [Key]
        public string PhoneNumber { get; set; }
        public List<Cart> CartItems { get; set; }
    }
}
