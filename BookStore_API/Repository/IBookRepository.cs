using BookStore_API.Models;

namespace BookStore_API.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();

    }
}
