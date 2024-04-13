using BookStoreMVC.Models;

namespace BookStoreMVC.Services
{
    public interface IUserService
    {
        Task<int> Login(string username, string password);
        Task<int> Logout();

        Task<int> Register(UserViewModel userViewModel);
    }
}
