using BookStore_API.Models;
using BookStore_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    //Comment from main branch
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetBooksAsync();
            return Ok(books); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookBgIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var id = await _bookRepository.AddNewBook(book);
            //Parameters: name of get Function, route values{bookId, controller} , id 
            return CreatedAtAction(nameof(GetBookById), new {id = id, controller = "Books"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            await _bookRepository.UpdateBook(id, book);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument book)
        {
            await _bookRepository.UpdateBookPatch(id, book);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
