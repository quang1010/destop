using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cake> cake { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Book>()
            //   .HasOne<Category>(s => s.Category)
            //   .WithMany(g => g.categorys)
            //   .HasForeignKey(s => s.CategoryId);
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Bánh ngọt"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Bánh mặn"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Bánh không đuờng"
                }
            );
        }
    }
}
