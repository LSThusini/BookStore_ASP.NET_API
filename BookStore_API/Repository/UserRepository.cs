using BookStore_API.Data;
using BookStore_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public UserRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<int> AddNewUser(User newUser)
        {
            _bookStoreContext.User.Add(newUser);
            await _bookStoreContext.SaveChangesAsync();
            return newUser.Id;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _bookStoreContext.User.Where(x => x.Id == id).Select(x => new User()
            {
                Id = x.Id,
                UserEmail = x.UserEmail,
                Password = x.Password,
            }).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
