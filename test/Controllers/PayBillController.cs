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
                string connectionString = "Data Source=restaurantdatabaseserver.database.windows.net;Initial Catalog=restaurantdb;Persist Security Info=True;User ID=sqladmin;Password=tqxyP7*9vgw4";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT ORDERID, OrderPrice, OrderStatus FROM ORDERS";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderDetails orderDetails = new OrderDetails();

                                orderDetails.orderId = "" + reader.GetDecimal(0);
                                orderDetails.orderPrice = "" + reader.GetDecimal(1);
                                orderDetails.orderStatus = reader.GetString(2);

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
        public string orderPrice;
        public string orderStatus;
    }
}
