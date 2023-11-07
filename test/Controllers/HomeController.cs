using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using test.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace test.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            public IActionResult RetrieveItems()
{
    var model = new List<CreateOrder>();

    string connectionString = "YourConnectionStringHere";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "SELECT Name, Price FROM MenuItems";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderDetails = new CreateOrder();
                        orderDetails.itemName = reader.GetString(0);
                        orderDetails.itemPrice = reader.GetDecimal(1).ToString();
                        model.Add(orderDetails);
                        Console.WriteLine(orderDetails.itemName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Pass the List of CreateOrder to the view with the menu items.
    return View("Index", model);
}

        }  
    }

    public class OrderDetails
    {
        public string itemName;
        public string itemPrice;
    }

