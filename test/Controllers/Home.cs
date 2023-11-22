using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
<<<<<<< Updated upstream
=======
        public IActionResult FastBarMenu()
        {
            return View();
        }


        [HttpPost]
        public IActionResult VerifyLogin(string searchInput)
        {
            return RedirectToAction("FastBarMenu", "FastBar");      //bypassing login verification
            int enteredPin;
            if (int.TryParse(searchInput, out enteredPin))
            {
                List<Pin> pins = GetPinsFromDatabase();

                if (pins.Exists(pin => pin.PinID == enteredPin))
                {
                    return RedirectToAction("FastBarMenu", "FastBar");
                }
                else
                {
                    string InvalidPinMsg = "Pin enetered is invalid";
                    return RedirectToAction("Index", "Home", InvalidPinMsg);
                }
            }

            return RedirectToAction("Error");
        }

        private List<Pin> GetPinsFromDatabase()
        {
            List<Pin> pins = new List<Pin>();

            string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT PinID FROM Pins";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int pinID = reader.GetInt32(0);
                            Pin pin = new Pin { PinID = pinID };
                            pins.Add(pin);
                        }
                    }
                }
            }

            return pins;
        }
>>>>>>> Stashed changes
    }
}
