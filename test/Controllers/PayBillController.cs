using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using test.Models;
using System.Collections.Generic;
using System.Data;

namespace test.Controllers
{
    public class PayBillController : Controller
    {
        public IActionResult PayBill()
        {
            var model = new PayBillModel();

            {
                string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT orderItem.OrderID, menuItem.ItemName, menuItem.ItemType, menuItem.ItemPrice FROM OrderItems orderItem INNER JOIN MenuItems menuItem ON orderItem.ItemID = menuItem.ItemID WHERE orderItem.OrderID = 2;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
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
                }
            }

            // Pass the list to the view as a model.
            return View(model);
        }
    }

    public class OrderDetails
    {
        public string orderId;
        public string itemName;
        public string itemType;
        public string itemPrice;
    }
