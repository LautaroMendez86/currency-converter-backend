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
        
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                return Ok(_userRepository.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(UserForCreation user)
        {
            User userCreated = _userRepository.Create(user);
            return Ok(userCreated);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
                _userRepository.UpdateSubscription(user);
                return Ok("Usuario actualizado correctamente");
        }

    }
}
