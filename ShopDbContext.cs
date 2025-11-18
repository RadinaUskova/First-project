using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstProducts.Data.Models;
using Microsoft.EntityFrameworkCore;
using CodeFirstProducts.Data.Models;

namespace CodeFirstProducts.Data
{
    

    public class ShopDbContext :DbContext
    {
        public DbSet<Product> Products { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.conString);
            }

            base.OnConfiguring(optionsBuilder);
        }
        public ShopDbContext()
        {

        }
        public ShopDbContext(DbContextOptions option)
            :base (option)
        {

        }
    }
}
