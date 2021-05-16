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
    }
}
