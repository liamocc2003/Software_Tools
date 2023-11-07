using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using test.Models; 
using System.Collections.Generic;

namespace test.Controllers
{
    public class PayBillController : Controller
    {
        public IActionResult PayBill()
        {
            var model = new PayBillModel();

            try
            {
                string connectionString = "Data Source=restaurantdatabaseserver.database.windows.net;Initial Catalog=restaurantdb;Persist Security Info=True;User ID=sqladmin;Password=***********";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT OrderID, OrderPrice, OrderStatus FROM ORDERS";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderDetails orderDetails = new OrderDetails
                                {
                                    OrderId = reader.GetInt32(0).ToString(),
                                    OrderPrice = reader.GetDecimal(1).ToString(), // Assuming orderPrice is a decimal
                                    OrderStatus = reader.GetString(2) // Assuming orderStatus is a string
                                };

                                model.ListOrderDetails.Add(orderDetails);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ideally, log this exception with a logging framework.
                Console.WriteLine("Exception: " + ex.ToString());
            }

            // Pass the list to the view as a model.
            return View(model);
        }
    }

    public class OrderDetails
    {
        public string? OrderId { get; set; }
        public string? OrderPrice { get; set; }
        public string? OrderStatus { get; set; }
    }
}
