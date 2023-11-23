using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using System.Data.SqlClient;

namespace test.Controllers.Tests
{

        [TestClass()]
        public class PayBillControllerTest
        {

            [TestMethod()]
            public void PayBill_ShouldRetrieveCorrectOrderDetails()
            {
                // Arrange
                var controller = new PayBillController();
                string validOrderId = "1"; // Replace with a valid order ID from your test data

                // Act
                var actionResult = controller.PayBill(validOrderId);

                // Assert ViewResult
                var viewResult = actionResult as ViewResult;
                if (viewResult == null)
                {
                    throw new InvalidOperationException("Expected action result to be of type ViewResult.");
                }

                // Assert Model
                var model = viewResult.Model as PayBillModel;
                if (model == null)
                {
                    throw new InvalidOperationException("Expected the model of the ViewResult to be of type PayBillModel.");
                }

                // Assert Bill Details
                // You need to know the expected bill details for the given orderID from your test data
                var expectedBillDetails = new List<BillDetails>
    {
        new BillDetails { itemName = "Spaghetti", itemQuantity = "2", itemPrice = "14.00" },
        // Add more expected items here based on your test data
    };

                if (model.ListBillDetails.Count != expectedBillDetails.Count)
                {
                    throw new InvalidOperationException($"Expected count {expectedBillDetails.Count}, but got {model.ListBillDetails.Count}");
                }

                for (int i = 0; i < expectedBillDetails.Count; i++)
                {
                    if (model.ListBillDetails[i].itemName != expectedBillDetails[i].itemName)
                    {
                        throw new InvalidOperationException($"Expected item name {expectedBillDetails[i].itemName}, but got {model.ListBillDetails[i].itemName}");
                    }

                    if (model.ListBillDetails[i].itemQuantity != expectedBillDetails[i].itemQuantity)
                    {
                        throw new InvalidOperationException($"Expected item quantity {expectedBillDetails[i].itemQuantity}, but got {model.ListBillDetails[i].itemQuantity}");
                    }

                    if (model.ListBillDetails[i].itemPrice != expectedBillDetails[i].itemPrice)
                    {
                        throw new InvalidOperationException($"Expected item price {expectedBillDetails[i].itemPrice}, but got {model.ListBillDetails[i].itemPrice}");
                    }
                }
            }

            string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; // Initialize with actual connection string

            [TestMethod()]
            public void ConnectToDatabase()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        // Perform some operations
                    }
                    catch (SqlException)
                    {
                        throw new InvalidOperationException("Failed to connect to the database. Please check connection string.");
                    }
                }
            }

            [TestMethod()]
            public void StatusPaid_UpdatesOrderStatus()
            {
                // Arrange
                var controller = new PayBillController();
                int orderId = 1; // Replace with an orderId known to be in the database

                // Act
                controller.StatusPaid(orderId);

                // Assert
                string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string sql = "SELECT OrderStatus FROM Orders WHERE OrderID = @OrderId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new InvalidOperationException("Order not found.");
                            }

                            string orderStatus = reader.GetString(0);
                            if (orderStatus != "U")
                            {
                                throw new InvalidOperationException($"Expected order status 'U', but got {orderStatus}");
                            }
                        }
                    }
                }
            }

        }
    }
   