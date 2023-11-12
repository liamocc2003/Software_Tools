using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using test.Models;

namespace test.Controllers
{
    public class EditOrdersController : Controller
    {
        public IActionResult EditOrders()
        {
            var model = new EditOrdersModel();

            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT menuItems.ItemName, orderItems.OrderQuantity, menuItems.ItemPrice FROM OrderItems orderItems INNER JOIN MenuItems menuItems ON orderItems.ItemID = menuItems.ItemID WHERE orderItems.OrderID = 2;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EditOrderDetails editOrderDetails = new EditOrderDetails();

                            editOrderDetails.itemName = "" + reader.GetString(0);
                            editOrderDetails.orderQuantity = "" + reader.GetDecimal(1);
                            editOrderDetails.itemPrice = "" + reader.GetDecimal(2);

                            model.listEditOrderDetails.Add(editOrderDetails);
                        }
                    }
                }
            }
            return View(model);
        }
    }
}

public class EditOrderDetails
{
    public string itemName;
    public string orderQuantity;
    public string itemPrice;
}
