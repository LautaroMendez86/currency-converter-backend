using CurrencyController.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionRepository _subscriptionRepository;
        public SubscriptionController(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_subscriptionRepository.Index());
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
