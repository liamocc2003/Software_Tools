using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using test.Models;
using System.Collections.Generic;
using System.Data;
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

        [HttpGet]
            public IActionResult RetrieveItems()
{
    var model = new CreateOrder();

    string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "SELECT ItemName, ItemPrice FROM MenuItems";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                            while (reader.Read())
                            {
                                OrderDetails orderDetails = new OrderDetails();

                                orderDetails.orderId = "" + reader.GetDecimal(0);
                                orderDetails.itemName = "" + reader.GetString(1);
                                orderDetails.itemType = "" + reader.GetString(2);
                                orderDetails.itemPrice = "" + reader.GetDecimal(3);

                                model.ListOrderDetails.Add(orderDetails);
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
    return View(model);
}

        }  
    }

    public class OrderDetails
    {
    public string orderId;
    public string itemName;
    public string itemType;
    public string itemPrice;
}

