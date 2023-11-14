using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using test.Models;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace test.Controllers
{
    public class FastBar : Controller
    {
        private readonly ILogger<FastBar> _logger;
        public FastBar(ILogger<FastBar> logger)
        {
            _logger = logger;
        }

        public IActionResult FastBarMenu()
        {
            CreateOrder model = new CreateOrder();

            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT menuItems.ItemName, menuItems.ItemPrice FROM MenuItems menuItems";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderDetails orderDetails = new OrderDetails();

                                orderDetails.itemName = reader.GetString(0);
                                orderDetails.itemPrice = reader.GetDecimal(1).ToString();

                                model.listOrderDetails.Add(orderDetails);
                            }
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                connection.Close();
            }

            // Pass the List of CreateOrder to the view with the menu items.
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateOrder(List<OrderDetails> selectedItems, string customerName)
        {
            int orderTableNumber = 1; //hard coded, where do we get table number?
            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           
            int orderID = GenerateOrderID();

            string insertOrderQuery = "INSERT INTO Orders (OrderID, OrderTableNO, OrderDate, OrderPrice, OrderStatus) VALUES (@OrderID, @OrderTableNO, GETDATE(), @OrderPrice, @OrderStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertOrderQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@OrderTableNO", orderTableNumber);
                    command.Parameters.AddWithValue("@OrderPrice", selectedItems.Sum(item => decimal.Parse(item.itemPrice))); // Assuming itemPrice is a string
                    command.Parameters.AddWithValue("@OrderStatus", "A");

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            return RedirectToAction("OrderSuccess");
        }

        private int GenerateOrderID()
        {
            int nextOrderID = 0;

            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; // Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT MAX(OrderID) FROM Orders";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        nextOrderID = Convert.ToInt32(result) + 1;
                    }
                }
                connection.Close();
            }

            return nextOrderID;
        }


    }
}

public class OrderDetails
{
    public string itemName = "";
    public string itemPrice = "";
}

