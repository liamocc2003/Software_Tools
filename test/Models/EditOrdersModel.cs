namespace test.Models
{
    public class EditOrdersModel
    {
        public List<EditOrderDetails> listEditOrderDetails { get; set; }

        public EditOrdersModel() 
        {
            listEditOrderDetails = new List<EditOrderDetails>();
        }
    }
}
