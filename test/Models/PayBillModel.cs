using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using test.Controllers;

namespace test.Models
{
        public class PayBillModel
        {
            public List<BillDetails> ListBillDetails { get; set; }

            public PayBillModel()
            {
                ListBillDetails = new List<BillDetails>();
            }
        }
    }
