using Microsoft.AspNetCore.Mvc;
using CurrencyController.Data.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CurrencyConverter.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConverterHistoryController : ControllerBase
{
   private readonly ConverterHistoryRepository _converterHistoryRepository;

   public ConverterHistoryController(ConverterHistoryRepository converterHistoryRepository)
   {
      _converterHistoryRepository = converterHistoryRepository;
   }
   [HttpGet("{userId}")]
   public IActionResult GetConverterHistory(int userId)
   {
      try
      {
         return Ok(_converterHistoryRepository.GetConverterHistory(userId));
      }
      catch (Exception e)
      {
         return StatusCode(500, e.Message);
      }
   }
}