using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
