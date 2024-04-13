using BookStoreMVC.Models;

namespace BookStoreMVC.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetBooksAsync();
        Task<int> Register(UserViewModel userViewModel);
        Task<UserViewModel> LoginUser(string userEmail, string userPassword);
    }
}
