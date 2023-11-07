using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class PayBillController : Controller
    {
        public IActionResult PayBill()
        {
            return View();
        }
    }
}
