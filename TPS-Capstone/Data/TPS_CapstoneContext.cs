using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace TPS_Capstone.Data
{
    public class TPS_CapstoneContext : DbContext
    {
        public TPS_CapstoneContext (DbContextOptions<TPS_CapstoneContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Models.Category> Category { get; set; } = default!;

        public DbSet<WebApplication3.Models.Customer>? Customer { get; set; }

        public DbSet<WebApplication3.Models.OrderItem>? OrderItem { get; set; }

        public DbSet<WebApplication3.Models.Orders>? Orders { get; set; }

        public DbSet<WebApplication3.Models.Product>? Product { get; set; }

        public DbSet<WebApplication3.Models.Rent>? Rent { get; set; }

        public DbSet<WebApplication3.Models.RentItem>? RentItem { get; set; }

        public DbSet<WebApplication3.Models.UserRoles>? UserRoles { get; set; }

        public DbSet<WebApplication3.Models.Users>? Users { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Has
        }*/
    }
}
