using System;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D2_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        // TODO: implement a DbSet<Author> property
        public DbSet<Author> Authors { get; set; }

        // This method runs once when the DbContext is first used.
        public BookContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
            base.OnConfiguring(optionsBuilder);
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "John", LastName = "Steinbeck", BirthDate = new DateTime(1902, 2, 27) },
                new Author { Id = 2, FirstName = "Andrew", LastName = "Brewer", BirthDate = new DateTime(1999, 10, 14) },
                new Author { Id = 3, FirstName = "Riley", LastName = "Mason", BirthDate = new DateTime(1979, 4, 4) });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Grapes of Wrath", AuthorId = 1 },
                new Book { Id = 2, Title = "More than Realistic", AuthorId = 2 },
                new Book { Id = 3, Title = "Sadistic Oppurtunities", AuthorId = 3 },
                new Book { Id = 4, Title = "The Talking Tree's", AuthorId = 3 });

            base.OnModelCreating(modelBuilder);
        }

    }
}

