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

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser( UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                // If model validation fails, return the same view with validation errors
                return View(user);
            }
            

            try
            {
                int userId = await _bookService.Register(user);
                if(userId != 0)
                {
                    return RedirectToAction("Books");
                }
                else
                {
                    return View(user);
                }
                
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}