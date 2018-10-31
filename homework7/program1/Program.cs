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
            //添加订单
            //string[] proname = new string[2];
            //int[] count = new int[2];
            //double[] price = new double[2];
            //for(int i = 0;i < 2;i++)
            //{
            //    Console.Write("请输入商品名称：");
            //    proname[i] = Console.ReadLine();
            //    Console.Write("请输入商品数量：");
            //    count[i] = Int32.Parse(Console.ReadLine());
            //    Console.Write("请输入商品单价：");
            //    price[i] = Double.Parse(Console.ReadLine());

            //}
            //order.AddOrder(5, "小明", proname, count, price);

            //order.FindOrder();

            order.RemoveOrder(1);
            //order.ReviseOrder(2,proname,count,price);
            //order.Export("order.xml");

            //List<Order> orderlist = OrderService.Import("order.xml") as List<Order>;
            //foreach (var n in orderlist)
            //{
            //    Console.WriteLine("订单号：" + n.ONum);
            //    Console.WriteLine("客户名：" + n.OName);
            //    for (int j = 0; j < n.oDlist.Count; j++)
            //    {
            //        Console.WriteLine("商品名：" + n.oDlist[j].Name + " 数量：" + n.oDlist[j].Count + " 单价：" + n.oDlist[j].Price);
            //    }
            //}
        }
    }
}
