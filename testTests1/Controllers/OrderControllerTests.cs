using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Controllers;
using test.Models;

namespace test.Controllers.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void Order_RetrievesActiveOrders()
        {
            // Arrange
            var controller = new OrderController();

            // Act
            var actionResult = controller.Order();

            // Assert
            var viewResult = actionResult as ViewResult;
            if (viewResult == null)
            {
                throw new InvalidOperationException("Expected action result to be of type ViewResult.");
            }

            var model = viewResult.Model as OrderModel;
            if (model == null)
            {
                throw new InvalidOperationException("Expected the model of the ViewResult to be of type OrderModel.");
            }

            // Fetch active orders directly from the database for comparison
            string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; // Initialize with actual connection string
            string sql = "SELECT orders.OrderID, orders.OrderTableNo, orders.OrderDate, orders.OrderPrice, orders.OrderStatus FROM Orders orders WHERE orders.OrderStatus = 'A';";

            var expectedOrders = new List<ViewOrderDetails>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new ViewOrderDetails
                            {
                                orderID = reader.GetDecimal(0).ToString(),
                                orderTableNo = reader.GetSqlSingle(1).ToString(),
                                orderDate = reader.GetDateTime(2).ToString(),
                                orderPrice = reader.GetDecimal(3).ToString(),
                                orderStatus = reader.GetString(4)
                            };
                            expectedOrders.Add(order);
                        }
                    }
                }
            }

            // Comparing database results with the model's data
            if (expectedOrders.Count != model.listViewOrderDetails.Count)
            {
                throw new InvalidOperationException($"Expected count {expectedOrders.Count}, but got {model.listViewOrderDetails.Count}");
            }

            for (int i = 0; i < expectedOrders.Count; i++)
            {
                if (!model.listViewOrderDetails.Any(x => x.orderID == expectedOrders[i].orderID &&
                                                         x.orderTableNo == expectedOrders[i].orderTableNo &&
                                                         x.orderDate == expectedOrders[i].orderDate &&
                                                         x.orderPrice == expectedOrders[i].orderPrice &&
                                                         x.orderStatus == expectedOrders[i].orderStatus))
                {
                    throw new InvalidOperationException("Mismatch between the model's data and the database.");
                }
            }
        }

        /*        [TestMethod]
            public void Order_WhenNoActiveOrders_ReturnsEmptyModel()
        {
            // Arrange
            var controller = new OrderController();

            // Setup database state: ensure no orders with status 'A'
            // This setup is not shown here but would involve ensuring the database is in the expected state

            // Act
            var actionResult = controller.Order();

            // Assert
            var viewResult = actionResult as ViewResult;
            if (viewResult == null)
            {
                throw new InvalidOperationException("Expected action result to be of type ViewResult.");
            }

            var model = viewResult.Model as OrderModel;
            if (model == null)
            {
                throw new InvalidOperationException("Expected the model of the ViewResult to be of type OrderModel.");
            }

            if (model.listViewOrderDetails.Any())
            {
                throw new InvalidOperationException("Expected no orders in the model, but found some.");
            }
        }*/

    }
}
