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
                string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT menuitem.ItemName, orderitem.OrderQuantity, menuitem.ItemPrice \r\nFROM OrderItems orderitem\r\nINNER JOIN MenuItems menuitem ON orderitem.ItemID = menuitem.ItemID\r\nWHERE orderitem.OrderID = 2;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BillDetails billDetails = new BillDetails();


                                billDetails.itemName = "" + reader.GetString(0);
                                billDetails.itemQuantity = "" + reader.GetDecimal(1);
                                billDetails.itemPrice = "" + reader.GetDecimal(2);
                                

                                model.ListBillDetails.Add(billDetails);
                            }
                        }
                    }
                }
            }
            return View(model);
        }
        public IActionResult StatusPaid(int orderId)
        {
            string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Orders SET OrderStatus = 'U' WHERE OrderID = @OrderId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Bill paid successfully");
                    }
                    else
                    {
                        Console.WriteLine("Bill payment unsuccessful");
                    }
                }
            }
            return RedirectToAction("Order", "Order");
        }
    }

    public class BillDetails
    {
        public string itemName;
        public string itemQuantity;
        public string itemPrice;
    }




}
