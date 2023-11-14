using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Controllers;

namespace test.Models
{
    public class CreateOrder
    {
        public List<OrderDetails> listOrderDetails { get; set; }

        public CreateOrder()
        {
            listOrderDetails = new List<OrderDetails>();
        }
    }
} 