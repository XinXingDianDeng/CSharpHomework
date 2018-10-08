using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        public int ONum;
        public string OName;
        public List<OrderDetails> oDlist;
        public Order(int onum,string oname)
        {
            ONum = onum;
            OName = oname;
            oDlist = new List<OrderDetails>();
            
        }


        public void SetOrder(string name, int count, double price)
        {
            OrderDetails order = new OrderDetails();
            order.Name = name;
            order.Count = count;
            order.Price = price;
            oDlist.Add(order);
        }

    }
}
