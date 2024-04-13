using BookStore_API.Models;

namespace BookStore_API.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAndPassAsync(string userEmail, string password);
        Task<int> AddNewUser(User newUser);
        
    }
}
