using CurrencyController.Data.Repository;
using CurrencyController.Models.Dto;
using CurrencyConverter.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavouriteController : ControllerBase
    {
        public FavouriteRepository _favouriteRepository;
        public FavouriteController(FavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult Index(int userId)
        {
            try
            {
                List<Currency> favourites = _favouriteRepository.Index(userId);

                return Ok(favourites);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(FavouriteToCreateAndDelete favourite)
        {
            try
            {
                _favouriteRepository.Create(favourite);

                return Ok("Se ha anadido correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(FavouriteToCreateAndDelete favourite)
        {
            try
            {
                 _favouriteRepository.Delete(favourite);

                return Ok("Se ha borrado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("currencies-id/{userId}")]
        public IActionResult GetCurrenciesId(int userId)
        {
            try
            {
                List<int> favoritesProducts = _favouriteRepository.GetCurrenciesId(userId);
                
                return Ok(favoritesProducts);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
