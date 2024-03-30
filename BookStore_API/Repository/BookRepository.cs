using BookStore_API.Data;
using BookStore_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext) {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await _bookStoreContext.Book.ToListAsync();
            return books;
        }
    }
}
