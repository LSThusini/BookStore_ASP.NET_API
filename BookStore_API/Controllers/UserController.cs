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

        [HttpGet]
        public async Task<IActionResult> LoginUser([FromQuery]string e, [FromQuery]string p)
        {
            var user = await _userRepository.GetUserByEmailAndPassAsync(e, p);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {

            var id = await _userRepository.AddNewUser(user);
            //Parameters: name of get Function, route values{userId, controller} , id 
            return CreatedAtAction(nameof(LoginUser), new { id = id, controller = "User" }, id);

        }
    }
}
