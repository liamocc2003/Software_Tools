namespace test.Models
{
    public class EditOrdersModel
    {
        public List<EditOrderDetails> listEditOrderDetails { get; set; }
        public List<EditOrderDetails> listEditOrderMenuItems { get; set; }

        public EditOrdersModel() 
        {
            listEditOrderDetails = new List<EditOrderDetails>();
            listEditOrderMenuItems = new List<EditOrderDetails>();
        }
    }
}
