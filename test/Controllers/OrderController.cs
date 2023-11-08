using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}
