using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hubtel.eCommerce.Cart.Api.Helper
{
    public class CartDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new Data.ECommerceDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<Data.ECommerceDbContext>>());
            //if (context.Customers.Any())
            //{
            //    return; 
            //}

            if (context.Items.Any())
            {
                return;
            }

            context.Items.AddRange(
                new Models.Cart
                {
                    ItemId = 1,
                    ItemName = "Milo",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0555966747"
                },
                new Models.Cart
                {
                    ItemId = 2,
                    ItemName = "Sugar",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0265995210"
                },
                new Models.Cart
                {
                    ItemId = 3,
                    ItemName = "Ideal Milk",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0265995210"
                },
                new Models.Cart
                {
                    ItemId = 4,
                    ItemName = "Pepsodent",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0555966747"
                },
                new Models.Cart
                {
                    ItemId = 5,
                    ItemName = "Insecticide",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0322005300"
                },
                new Models.Cart
                {
                    ItemId = 6,
                    ItemName = "Oil",
                    Quantity = 1,
                    UnitPrice = 16.5m,
                    Time = DateTime.UtcNow,
                    PhoneNumber = "0322005300"
                });

            //context.Customers.AddRange(new Customer()
            //{
            //    PhoneNumber = "0265995210", CartItems = new List<Models.Cart>()
            //    {
            //        new Models.Cart
            //        {
            //            ItemId = 1,
            //            ItemName = "Milo",
            //            Quantity = 1,
            //            UnitPrice = 16.5m,
            //            Time = DateTime.UtcNow
            //        },
            //        new Models.Cart
            //        {
            //            ItemId = 2,
            //            ItemName = "Sugar",
            //            Quantity = 2,
            //            UnitPrice = 10m,
            //            Time = DateTime.UtcNow
            //        }
            //    }
            //}, new Customer()
            //{
            //    PhoneNumber = "0555966747",
            //    CartItems = new List<Models.Cart>()
            //    {
            //        new Models.Cart
            //        {
            //            ItemId = 3,
            //            ItemName = "Ideal Milk",
            //            Quantity = 1,
            //            UnitPrice = 16.5m,
            //            Time = DateTime.UtcNow
            //        },
            //        new Models.Cart
            //        {
            //            ItemId = 4,
            //            ItemName = "Pepsodent",
            //            Quantity = 1,
            //            UnitPrice = 16.5m,
            //            Time = DateTime.UtcNow
            //        },
            //        new Models.Cart
            //        {
            //            ItemId = 5,
            //            ItemName = "Insecticide",
            //            Quantity = 1,
            //            UnitPrice = 16.5m,
            //            Time = DateTime.UtcNow
            //        }
            //    }
            //}, new Customer()
            //{
            //    PhoneNumber = "0322005300",
            //    CartItems = new List<Models.Cart>()
            //    {
            //        new Models.Cart
            //        {
            //            ItemId = 4,
            //            ItemName = "Pepsodent",
            //            Quantity = 1,
            //            UnitPrice = 8m,
            //            Time = DateTime.UtcNow
            //        },
            //        new Models.Cart
            //        {
            //            ItemId = 5,
            //            ItemName = "Insecticide",
            //            Quantity = 1,
            //            UnitPrice = 15m,
            //            Time = DateTime.UtcNow
            //        },
            //        new Models.Cart
            //        {
            //            ItemId = 6,
            //            ItemName = "Oil",
            //            Quantity = 3,
            //            UnitPrice = 20,
            //            Time = DateTime.UtcNow
            //        }
            //    }
            //});

            context.SaveChanges();
        }
    }
}
