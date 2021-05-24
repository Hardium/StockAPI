using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.EAN)
                .IsRequired();

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.EAN).IsUnique();
            });
        }
        #endregion

    }
}
