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
            _httpClient.BaseAddress = new Uri("http://localhost:5289/api/");
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
    }
}
