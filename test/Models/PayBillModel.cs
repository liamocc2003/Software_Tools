using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Controllers;

namespace test.Models
{
        public class PayBillModel
        {
            public List<OrderDetails> ListOrderDetails { get; set; }

            public PayBillModel()
            {
                ListOrderDetails = new List<OrderDetails>();
            }
        }
    }
