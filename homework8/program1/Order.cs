using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    public class Order
    {
        public string ONum { set; get; }
        public string OName { get; set; }
        public int DCount { get; set; }
        public double sumPri { get; set; }
        public string Tel { set; get; }
        public List<OrderDetails> oDlist { get; set; }
        public Order() { }
        public Order(string onum, string oname,string tel)
        {
            ONum = onum;
            OName = oname;
            Tel = tel;
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
