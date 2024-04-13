using BookStore_API.Models;

namespace BookStore_API.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<int> AddNewUser(User newUser);
        
    }
}
