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
                    string sql = "SELECT menuitem.ItemName, menuitem.ItemType, orderitem.OrderQuantity, menuitem.ItemPrice \r\nFROM OrderItems orderitem\r\nINNER JOIN MenuItems menuitem ON orderitem.ItemID = menuitem.ItemID\r\nWHERE orderitem.OrderID = 2;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderDetails orderDetails = new OrderDetails();

                                
                                orderDetails.itemName = "" + reader.GetString(0);
                                orderDetails.itemType = "" + reader.GetString(1);
                                orderDetails.orderItemQuantity = "" + reader.GetDecimal(2);
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
        public string itemName;
        public string itemType;
        public string orderItemQuantity;
        public string itemPrice;

    }
}
