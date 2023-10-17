using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginHTML()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginHTML(LoginModel model)
        {
            return View();
        }

        public IActionResult LoginTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginTag(LoginModel model)
        {
            return View();
        }
    }
}
