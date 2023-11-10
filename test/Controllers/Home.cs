using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
