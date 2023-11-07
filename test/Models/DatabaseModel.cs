namespace test.Models
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Other properties related to OrderItems
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        // Method to calculate the total order price based on order items
        public void CalculateTotalPrice()
        {
            OrderPrice = OrderItems.Sum(item => item.UnitPrice * item.Quantity);
        }
    }

}
