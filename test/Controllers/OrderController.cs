using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection;
using test.Models;

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
