using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPS_Capstone.Models;

namespace TPS_Capstone.Data
{
    public class TPS_CapstoneContext : DbContext
    {
        public TPS_CapstoneContext (DbContextOptions<TPS_CapstoneContext> options)
            : base(options)
        {
        }

        public DbSet<TPS_Capstone.Models.Category> Category { get; set; } = default!;

        public DbSet<TPS_Capstone.Models.OrderType>? OrderType { get; set; }

        public DbSet<TPS_Capstone.Models.Product>? Product { get; set; }

        public DbSet<TPS_Capstone.Models.Rent>? Rent { get; set; }

        public DbSet<TPS_Capstone.Models.User>? User { get; set; }

        public DbSet<TPS_Capstone.Models.UserRole>? UserRole { get; set; }
    }
}
