using System.Data;

namespace test
{
    public class Order
    {
        private int OrderId;
        private int OrderTableNo;
        private DateTime OrderDate;
        private double OrderPrice;
        private char OrderStatus;

        public Order() {
            this.OrderId = 0;
            this.OrderTableNo = 0;
            this.OrderDate = DateTime.Now;
            this.OrderPrice = 0;
            this.OrderStatus = 'Y';
        }

        public Order(int orderId, int orderTableNo, DateTime orderDate, double orderPrice, char orderStatus)
        {
            this.OrderId = orderId;
            this.OrderTableNo = orderTableNo;
            this.OrderDate = orderDate;
            this.OrderPrice = orderPrice;
            this.OrderStatus = orderStatus;
        }

        public int getOrderID()
        {
            return this.OrderId;
        }
        public int getOrderTableNo()
        {
            return this.OrderTableNo;
        }
        public DateTime getOrderDate()
        {
            return this.OrderDate;
        }
        public double getOrderPrice()
        {
            return this.OrderPrice;
        }
        public char getOrderStatus()
        {
            return this.OrderStatus;
        }

        public void setOrderID(int orderId)
        {
            OrderId = orderId;
        }
        public void setOrderTableNo(int orderTableNo)
        {
            OrderTableNo = orderTableNo;
        }
        public void setOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }
        public void setOrderPrice(double orderPrice)
        {
            OrderPrice = orderPrice;
        }
        public void setOrderStatus(char orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public void AddtoOrder()
        {
            //connect to database and do update query on Order with matching id
        }

        public void removeFromOrder()
        {
            //connect to database and remove item from Order with matching id
        }

        public static DataSet getOrderDetails()
        {
            //connect to database and find order from id, pull needed data into DataSet and return DataSet
            return new DataSet();
        }

        public static LinkedList<String> OrderItemSearch()
        {
            //connect to database and search through order with matching id for item entered
            return new LinkedList<String>();
        }
        
        public static float getOrderTotal()
        {
            //connect to database and get sum of Order items price
            return 0;
        }
    }
}
