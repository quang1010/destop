using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Book.data.Entities;
using System.Threading.Tasks;

namespace Book.data.EF
{
    public class BookDbContext : DbContext
    {
        public BookDbContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book.data.Entities.Book> Books { get; set; }
        public DbSet<Book.data.Entities.Category> Categories { get; set; }
    }
}
