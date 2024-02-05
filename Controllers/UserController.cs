using CurrencyController.Data.Repository;
using CurrencyController.Models.Dto;
using CurrencyConverter.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<User> Users = _userRepository.Index();

            if (Users.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(Users);
        }

        [HttpPost]
        public IActionResult Create(UserForCreation user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            User userCreated = _userRepository.Create(user);

            return Ok(userCreated);
        }

    }
}
