using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using System.Data.SqlClient;
using System;

namespace test.Controllers.Tests
{
    [TestClass()]
    public class PayBillControllerTests
    {
        [TestMethod()]
        public void PayBillTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StatusPaidTest()
        {
            Assert.Fail();
        }

        // Test Cases for PayBill Action

        string connectionString = "Server=tcp:restaurantdatabaseserver2.database.windows.net,1433;Initial Catalog=restaurantdb;Persist Security Info=False;User ID=adminBilly;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private object orderId;

        //Test Case 1: Verify that the action retrieves the correct item names, quantities, and prices for a given order ID.

        public void PayBill_ShouldRetrieveCorrectOrderDetails()
        {
    // Arrange
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT itemName, orderItemQuantity, itemPrice FROM OrderDetails WHERE orderId = @orderId", connection);
                command.Parameters.AddWithValue("@orderId", orderId);

                List<OrderDetails> expectedData = new List<OrderDetails>();
                using (SqlDataReader reader = command.ExecuteReader())
                    {
                while (reader.Read())
                {
                expectedData.Add(new OrderDetails
                {
                    itemName = reader.GetString(0),
                    itemQuantity = reader.GetString(1),
                    itemPrice = reader.GetDecimal(2).ToString("0.00")
                });
            }
        }

        var controller = new PayBillController(); // Assuming the controller doesn't require the database in the constructor

        // Act
        var result = controller.PayBill();


                // Assert

                var model = new PayBillModel();
                Assert.Equals(expectedData.Count, model.ListBillDetails.Count);
                for (int i = 0; i < expectedData.Count; i++)
                {
                    Assert.Equals(expectedData[i].itemName, model.ListBillDetails[i].itemName);
                    Assert.Equals(expectedData[i].itemQuantity, model.ListBillDetails[i].itemQuantity);
                    Assert.Equals(expectedData[i].itemPrice, model.ListBillDetails[i].itemPrice);
                }
            }
        }

        // Test Case 2: Check the response when the database connection fails.
        /*
            [Fact]
            public void PayBill_ShouldHandleDatabaseConnectionFailure()
            {
                // Arrange
                var mockDb = new Mock<IDatabase>();
                mockDb.Setup(db => db.Query()).Throws(new SqlException());
                var controller = new PayBillController(mockDb.Object);

                // Act & Assert
                var exception = Record.Exception(() => controller.PayBill());
                Assert.Null(exception); 
            }
        */

        // Test Case 3: Confirm behavior when no items are associated with an order ID.
        /*
            [Fact]
            public void PayBill_ShouldReturnEmptyModelWhenNoOrderDetails()
            {
                // Arrange
                var mockDb = new Mock<IDatabase>();
                mockDb.Setup(db => db.Query()).Returns(new List<OrderDetails>()); // Return an empty list
                var controller = new PayBillController(mockDb.Object);

                // Act
                var result = controller.PayBill();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<PayBillModel>(viewResult.Model);
                Assert.Empty(model.ListOrderDetails); 
            }
        */



        // Test Cases for StatusPaid Action

        // Test Case 4: Verify that the order status is updated to 'U' when a valid order ID is provided.
        /*
        [Fact]
        public void StatusPaid_ShouldUpdateStatusToU_WithValidOrderId()
        {
        // Arrange
        var validOrderId = 1; // Assume this is a valid order ID
        var mockDb = new Mock<IDatabase>(); 
        mockDb.Setup(db => db.Execute()).Returns(1); 

        var controller = new PayBillController(mockDb.Object);

        // Act
        var result = controller.StatusPaid(validOrderId);

        // Assert
        
    }
*/

        // Test Case 5: Check the behavior when an invalid order ID is provided.
        /*
            [Fact]
            public void StatusPaid_ShouldIndicateUnsuccessfulPayment_WithInvalidOrderId()
            {
                // Arrange
                var invalidOrderId = -1; // Invalid OrderID
                var mockDb = new Mock<IDatabase>();
                mockDb.Setup(db => db.Execute()).Returns(0); // Simulate zero rows affected (failure)

                var controller = new PayBillController(mockDb.Object);

                // Act
                var result = controller.StatusPaid(invalidOrderId);

                // Assert
                mockDb.Verify(db => db.Execute(), Times.Once());
            }
        */

        // Test Case 6: Test the response when the database connection fails.
        /*
            [Fact]
            public void StatusPaid_ShouldHandleDatabaseConnectionFailure()
            {
                // Arrange
                var mockDb = new Mock<IDatabase>();
                mockDb.Setup(db => db.Execute()).Throws(new Exception()); // Simulate a database failure

                var controller = new PayBillController(mockDb.Object);

                // Act & Assert
                var exception = Record.Exception(() => controller.StatusPaid(1));
                Assert.Null(exception); // No exception should be thrown
            }
        */
    }
}

