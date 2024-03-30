using BookStore_API.Data;
using BookStore_API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<Book> GetBookBgIdAsync(int id)
        {
            var book = await _bookStoreContext.Book.Where(x => x.Id == id).Select(x => new Book() 
            { 
                Id = x.Id,
                Title = x.Title,
                Description = x.Description}).FirstOrDefaultAsync();
            return book;
        }

        public async Task<int> AddNewBook(Book newBook)
        {
            _bookStoreContext.Book.Add(newBook);
            await _bookStoreContext.SaveChangesAsync();
            return newBook.Id;

        }

        public async Task UpdateBook(int bookId, Book updatedBook)
        {
            //var book = await _bookStoreContext.Book.FindAsync(bookId);
            //if(book != null) {
            //    book.Title = updatedBook.Title;
            //    book.Description = updatedBook.Description;

            //    await _bookStoreContext.SaveChangesAsync();

            //}


            //This approach calls the database only once.
            var newBook = new Book()
            {
                Id = bookId,
                Title = updatedBook.Title,
                Description = updatedBook.Description,
            };

            _bookStoreContext.Book.Update(newBook);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task UpdateBookPatch(int bookId, JsonPatchDocument updatedBook)
        {
            var book = await _bookStoreContext.Book.FindAsync(bookId);
            if(book != null)
            {
                updatedBook.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
            }

        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Book() { Id = id };
            _bookStoreContext.Book.Remove(book);
            await _bookStoreContext.SaveChangesAsync();

        }
    }
}
