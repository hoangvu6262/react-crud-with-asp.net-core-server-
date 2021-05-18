using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Models
{
    public class MobileShopDbContext:DbContext
    {
        public MobileShopDbContext(DbContextOptions<MobileShopDbContext> options):base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
