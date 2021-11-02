using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Cart> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cart>()
                .HasKey(c => new { c.ItemId, c.PhoneNumber });
        }
    }
}
