using BookStore_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Data
{
    public class BookStoreContext : DbContext
    {

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : 
            base(options)
        {
        }

        public DbSet<Book> Book { get; set; } //Create a table with the name Book
        public DbSet<User> User { get; set; } //Create a table with the name User

    }
}
