using System.Data;

namespace test
{
    public class Menu
    {
        private int ItemId;
        private char ItemType;
        private string ItemName;
        private string ItemDescription;
        private float ItemPrice;
        private char ItemStatus;

        public Menu()
        {
            this.ItemId = 0;
            this.ItemType = 'Y';
            this.ItemName = string.Empty;
            this.ItemDescription = "";
            this.ItemPrice = 0;
            this.ItemStatus = 'Y';
        }
        
        public Menu(int itemId, char itemType, string itemName, string itemDescription, float itemPrice, char itemStatus)
        {
            this.ItemId= itemId;
            this.ItemType= itemType;
            this.ItemName = itemName;
            this.ItemDescription = itemDescription;
            this.ItemPrice = itemPrice;
            this.ItemStatus = itemStatus;
        }

        public int getItemID()
        {
            return this.ItemId;
        }
        public char getItemType()
        {
            return this.ItemType;
        }
        public string getItemName()
        {
            return this.ItemName;
        }
        public string getItemDescription()
        {
            return this.ItemDescription;
        }
        public float getItemPrice()
        {
            return this.ItemPrice;
        }
        public char getItemStatus()
        {
            return this.ItemStatus;
        }

        public void setItemID(int itemID)
        {
            ItemId = itemID;
        }
        public void setItemType(char itemType)
        {
            ItemType = itemType;
        }
        public void setItemName(string itemName)
        {
            ItemName = itemName;
        }
        public void setItemDescription(string itemDescription)
        {
            ItemDescription = itemDescription;
        }
        public void setItemPrice(float itemPrice)
        {
            ItemPrice = itemPrice;
        }
        public void setItemStatus(char itemStatus)
        {
            ItemStatus = itemStatus;
        }

        public static DataSet getMenuDetails()
        {
            //connect to database and find menu items from type, pull needed data into DataSet and return DataSet
            return new DataSet();
        }
    }
}
