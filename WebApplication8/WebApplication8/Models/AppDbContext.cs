using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Flower> Flowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flower>().HasData(
              new Flower()
              {
                  AvatarPath = "images/lan1.jpg",
                  TypeF = Dept.Hoa_Lan,
                  
                  Id = 1,
                  Name = "Lan Vàng"
              },
                new Flower()
                {
                    AvatarPath = "images/giaytim.jpg",
                    TypeF = Dept.Hoa_Giấy,
                   
                    Id = 2,
                    Name = "Hoa Giấy Tím"
                }
            );
        }
    }


}
