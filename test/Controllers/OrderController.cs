using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection;
using test.Models;

namespace test.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            OrderModel model = new OrderModel();

            string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //Select Orders
                string sql1 = "SELECT orders.OrderID, orders.OrderTableNo, orders.OrderDate, orders.OrderPrice, orders.OrderStatus FROM Orders orders WHERE orders.OrderStatus = 'A';";

                using (SqlCommand command = new SqlCommand(sql1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ViewOrderDetails viewOrderDetails = new ViewOrderDetails();

                            viewOrderDetails.orderID = reader.GetDecimal(0).ToString();
                            viewOrderDetails.orderTableNo = reader.GetSqlSingle(1).ToString();
                            viewOrderDetails.orderDate = reader.GetDateTime(2).ToString();
                            viewOrderDetails.orderPrice = reader.GetDecimal(3).ToString();
                            viewOrderDetails.orderStatus = reader.GetString(4);

                            model.listViewOrderDetails.Add(viewOrderDetails);
                        }
                    }
                }
                connection.Close();
            }
            return View(model);
        }
    }
}

public class ViewOrderDetails
{
    public string orderID;
    public string orderTableNo;
    public string orderDate;
    public string orderPrice;
    public string orderStatus;
}
