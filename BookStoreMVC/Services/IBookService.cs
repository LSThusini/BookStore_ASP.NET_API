using BookStoreMVC.Models;

namespace BookStoreMVC.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetBooksAsync();
    }
}
