namespace test.Models
{
    public class OrderModel
    {
        public List<ViewOrderDetails> listViewOrderDetails { get; set; }

        public OrderModel() 
        {
            listViewOrderDetails = new List<ViewOrderDetails>();
        }
    }
}
