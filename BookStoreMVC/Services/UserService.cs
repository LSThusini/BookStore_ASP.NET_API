using BookStoreMVC.Models;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace BookStoreMVC.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5289/api/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<int> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<int> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Register(UserViewModel userViewModel)
        {
            UserViewModel newUser = new UserViewModel();
            newUser.UserEmail = userViewModel.UserEmail;
            newUser.Password = Secrecy.HashPassword(userViewModel.Password);
            var response = await _httpClient.PatchAsJsonAsync("User", newUser);

            if (response.IsSuccessStatusCode)
            {
                int id =  response.Content.ReadAsAsync<int>().Result;
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
