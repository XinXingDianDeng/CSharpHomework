using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService order = new OrderService();
            //order.AddOrder(5, "小明");
            order.FindOrder();
            //order.RemoveOrder(1);
        }
    }
}
