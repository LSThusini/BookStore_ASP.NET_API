using BookStore_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore_API.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookBgIdAsync(int id);
        Task<int> AddNewBook(Book newBook);
        Task UpdateBook(int bookId, Book updatedBook);
        Task UpdateBookPatch(int bookId, JsonPatchDocument updatedBook);
        Task DeleteBookAsync(int bookId);

    }
}
