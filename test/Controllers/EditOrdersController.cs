using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using test.Models;

namespace test.Controllers
{
    public class EditOrdersController : Controller
    {
        public IActionResult EditOrders()
        {
            EditOrdersModel model = new EditOrdersModel();

            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //Select Order Items
                string sql1 = "SELECT menuItems.ItemName, orderItems.OrderQuantity, menuItems.ItemPrice FROM OrderItems orderItems ON orderItems.ItemID = menuItems.ItemID WHERE orderItems.OrderID = 2;";

                using (SqlCommand command = new SqlCommand(sql1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EditOrderDetails editOrderDetails = new EditOrderDetails();

                            editOrderDetails.itemName = reader.GetString(0);
                            editOrderDetails.orderQuantity = reader.GetDecimal(1).ToString();
                            editOrderDetails.itemPrice = reader.GetDecimal(2).ToString();

                            model.listEditOrderDetails.Add(editOrderDetails);
                        }
                    }
                }
                //Select Menu Items
                string sql2 = "SELECT menuItems.ItemName, menuItems.ItemDescription, menuItems.ItemPrice FROM MenuItems menuItems;";

                using (SqlCommand command = new SqlCommand(sql2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EditOrderDetails editOrderDetails = new EditOrderDetails();

                            editOrderDetails.itemName = reader.GetString(0);
                            editOrderDetails.itemDescription = reader.GetString(1);
                            editOrderDetails.itemPrice = reader.GetDecimal(2).ToString();

                            model.listEditOrderMenuItems.Add(editOrderDetails);
                        }
                    }
                }
                connection.Close();
            }
            return View(model);
        }

        //Change the displayed menuItems
        /*[HttpPost]
        public IActionResult DisplayMenuItems(char itemType)
        {
            EditOrdersModel model = new EditOrdersModel();

            string connectionString = "Server=tcp:restaurantdatabaseserver.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT menuItems.ItemName, menuItems.ItemDescription, menuItems.ItemPrice FROM MenuItems menuItems WHERE menuItems.ItemType = @itemType;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@itemType", itemType);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EditOrderDetails editOrderDetails = new EditOrderDetails();

                            editOrderDetails.itemName = reader.GetString(0);
                            editOrderDetails.itemDescription = reader.GetString(1);
                            editOrderDetails.itemPrice = reader.GetDecimal(2).ToString();

                            model.listEditOrderMenuItems.Add(editOrderDetails);
                        }
                    }
                }
                connection.Close();
            }
            return View(model);
        }*/
    }
}

public class EditOrderDetails
{
    public string itemName;
    public string orderQuantity;
    public string itemPrice;
    public string itemDescription;
}
