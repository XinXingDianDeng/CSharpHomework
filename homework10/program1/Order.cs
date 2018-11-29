using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace program2
{
    public class Order
    {
        [Key]
        public string ONum { set; get; }
        public string OName { get; set; }        
        public double sumPri { get; set; }
        public string Tel { set; get; }
        public List<OrderDetails> oDlist { get; set; }
        public Order() {
            oDlist = new List<OrderDetails>();
        }
        public Order(string onum, string oname,string tel,List<OrderDetails>odlist)
        {
            ONum = onum;
            OName = oname;
            Tel = tel;
            oDlist = odlist;
            foreach(var n in oDlist)
            {
                sumPri = n.Count * n.Price;
            }
        }


        //public void SetOrder(string name, int count, double price)
        //{
        //    OrderDetails order = new OrderDetails();
        //    order.SetDetails(name, count, price);            
        //    sumPri += price * count;
        //    oDlist.Add(order);
        //}

    }
}
