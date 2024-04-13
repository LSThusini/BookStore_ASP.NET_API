using BookStore_API.Models;
using BookStore_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromQuery]int id)
        {
            var book = await _userRepository.GetUserByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {

            var id = await _userRepository.AddNewUser(user);
            //Parameters: name of get Function, route values{userId, controller} , id 
            return CreatedAtAction(nameof(GetUserById), new { id = id, controller = "User" }, id);

        }
    }
}
