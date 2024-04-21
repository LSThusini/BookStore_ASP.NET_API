using BookStoreMVC.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BookStoreMVC.Services
{
    public class BookService : IBookService
    {
       
        private readonly HttpClient _httpClient;

        public BookService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7002/api/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
        {

            var response = await _httpClient.GetAsync("Books");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<BookViewModel>  booksList = response.Content.ReadAsAsync<IEnumerable<BookViewModel>>().Result;
                return booksList;
            }
            else
            {
                
                return null;
            }
        }

        public async Task<UserViewModel> LoginUser(string userEmail, string userPassword)
        {
            UserViewModel newUser = new UserViewModel();
            string hashedPass = Secrecy.HashPassword(userPassword);
            var response = await _httpClient.GetAsync("User/email/password?e="+userEmail+"&p="+hashedPass);
            if (response.IsSuccessStatusCode)
            {
                newUser = response.Content.ReadAsAsync<UserViewModel>().Result;
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Register(UserViewModel userViewModel)
        {
            UserViewModel newUser = new UserViewModel();
            newUser.UserEmail = userViewModel.UserEmail;
            newUser.Password = Secrecy.HashPassword(userViewModel.Password);
            var response = await _httpClient.PostAsJsonAsync("User", newUser);

            if (response.IsSuccessStatusCode)
            {
                int id = response.Content.ReadAsAsync<int>().Result;
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
