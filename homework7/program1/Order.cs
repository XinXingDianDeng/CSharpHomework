using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    public class Order
    {
        public int ONum { set; get; }
        public string OName { get; set; }
        public int DCount { get; set; }
        public double sumPri { get; set; }
        public List<OrderDetails> oDlist { get; set; }
        public Order() { }
        public Order(int onum, string oname)
        {
            ONum = onum;
            OName = oname;
            oDlist = new List<OrderDetails>();

        }


        public void SetOrder(string name, int count, double price)
        {
            OrderDetails order = new OrderDetails();
            order.SetDetails(name, count, price);            
            sumPri += price * count;
            oDlist.Add(order);
        }

    }
}
