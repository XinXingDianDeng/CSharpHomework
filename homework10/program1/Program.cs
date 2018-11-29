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
            OrderService orderService = new OrderService();
            List<OrderDetails> details = new List<OrderDetails>()
            {
                new OrderDetails("1","refrigerator",10,3500),
                new OrderDetails("2","televison",15,2999)                
            };
            Order order1 = new Order("20181129007", "xiaoming", "13097979936", details);
            List<OrderDetails> details2 = new List<OrderDetails>()
            {
                new OrderDetails("4","pig",10,500),
                new OrderDetails("5","egg",15,2)
            };
            Order order2 = new Order("20181129005", "shen", "13241479936", details2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            //orderService.ReviseOrder(order1);



        }
    }
}
