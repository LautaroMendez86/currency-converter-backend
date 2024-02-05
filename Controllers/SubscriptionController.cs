using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
