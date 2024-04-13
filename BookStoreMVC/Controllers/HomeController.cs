using BookStoreMVC.Models;
using BookStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IBookService _bookService;

        public HomeController( IBookService bookService)
        {
            //_logger = logger;
            _bookService = bookService;
        }

        public async Task<IActionResult> Books()
        {
            IEnumerable<BookViewModel> bookList = await _bookService.GetBooksAsync();
            return View(bookList);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}