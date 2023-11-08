using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Controllers;

namespace test.Models
{
    public class CreateOrder
    {
        public string itemName { get; set; }
        public string itemPrice { get; set; }
        public List<OrderDetails> ListOrderDetails { get; set; }

        public CreateOrder()
        {
            ListOrderDetails = new List<OrderDetails>();
            Console.WriteLine("I am working");
        }
    }
} 