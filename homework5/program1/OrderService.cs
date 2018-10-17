using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        List<Order> olist = new List<Order>();
        public OrderService()
        {

            Order order1 = new Order(1, "王老板");
            order1.SetOrder("雪碧", 10, 3.5);
            order1.SetOrder("可乐", 15, 4.0);
            order1.SetOrder("鲜橙多", 12, 7.0);
            order1.DCount = 3;
            Order order2 = new Order(2, "李先生");
            order2.SetOrder("瓜子", 20, 5.0);
            order2.SetOrder("薯片", 8, 5.5);
            order2.SetOrder("可乐", 12, 3.8);
            order2.DCount = 3;
            olist.Add(order1);
            olist.Add(order2);

        }

        public int AddOrder(int onum, string oname)
        {
            Order order = new Order(onum, oname);
            outer:;
            Console.Write("请输入商品名称：");
            string proName = Console.ReadLine();
            Console.Write("请输入商品数量：");
            int count = Int32.Parse(Console.ReadLine());
            Console.Write("请输入商品单价：");
            double price = Double.Parse(Console.ReadLine());
            order.SetOrder(proName, count, price);
            order.DCount++;
            olist.Add(order);
            int i = 0;
            Console.WriteLine("是否继续添加商品，是输入1，否输入0");
            i = Int32.Parse(Console.ReadLine());
            if (i == 1)
            {
                goto outer;
            }
            else
            {
                return 0;
            }
        }

        public void RemoveOrder(int onum)
        {
            foreach (Order order in olist)
            {

                try
                {
                    if (order.ONum == onum)
                    {
                        olist.Remove(order);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("错误");
                }

            }

        }

        public void ReviseOrder()
        {
            Console.Write("请输入要修改的订单号：");
            int onum = Int32.Parse(Console.ReadLine());
            foreach (Order order in olist)
            {
                try
                {
                    if (order.ONum == onum)
                    {
                        RemoveOrder(onum);
                        AddOrder(onum, order.OName);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("错误");
                }
            }
        }

        public void FindOrder()
        {
            Console.WriteLine("请选择查询服务：1.按订单号查询 2.按客户名查询 3.按商品名查询 " +
                "4.查询订单金额超过1万的商品");
            int i = Int32.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        Console.Write("请输入要查询的订单号：");
                        int onum = Int32.Parse(Console.ReadLine());
                        var m = from n in olist
                                where n.ONum == onum
                                select n;
                        foreach(var n in m)
                        {
                            Console.WriteLine("订单号：" + n.ONum);
                            Console.WriteLine("客户名：" + n.OName);
                            for (int j = 0; j < n.oDlist.Count; j++)
                            {
                                Console.WriteLine("商品名：" + n.oDlist[j].Name + " 数量：" + n.oDlist[j].Count + " 单价：" + n.oDlist[j].Price);
                            }
                        }
                        //foreach (Order order in olist)
                        //{
                        //    if (order.ONum == onum)
                        //    {
                        //        Console.WriteLine("订单号：" + order.ONum);
                        //        Console.WriteLine("客户名：" + order.OName);
                        //        for (int j = 0; j < order.oDlist.Count; j++)
                        //        {
                        //            Console.WriteLine("商品名：" + order.oDlist[j].Name + " 数量：" + order.oDlist[j].Count + " 单价：" + order.oDlist[j].Price);
                        //        }
                        //    }
                        //}
                    }
                    break;
                case 2:
                    {
                        Console.Write("请输入要查询的客户名：");
                        string name = Console.ReadLine();
                        var m = from n in olist
                                where n.OName == name
                                select n;
                        foreach (var n in m)
                        {
                            Console.WriteLine("订单号：" + n.ONum);
                            Console.WriteLine("客户名：" + n.OName);
                            for (int j = 0; j < n.oDlist.Count; j++)
                            {
                                Console.WriteLine("商品名：" + n.oDlist[j].Name + " 数量：" + n.oDlist[j].Count + " 单价：" + n.oDlist[j].Price);
                            }
                        }
                        //foreach (Order order in olist)
                        //{
                        //    if (order.OName == name)
                        //    {
                        //        Console.WriteLine("订单号：" + order.ONum);
                        //        Console.WriteLine("客户名：" + order.OName);
                        //        for (int j = 0; j < order.oDlist.Count; j++)
                        //        {
                        //            Console.WriteLine("商品名：" + order.oDlist[j].Name + " 数量：" + order.oDlist[j].Count + " 单价：" + order.oDlist[j].Price);
                        //        }
                        //    }
                        //}
                    }
                    break;
                case 3:
                    {
                        Console.Write("请输入要查询的商品名：");
                        string proName = Console.ReadLine();
                        
                        foreach(var p in olist)
                        {
                            var m = from n in p.oDlist
                                    where n.Name == proName
                                    select p;
                            foreach (var n in m)
                            {
                                Console.WriteLine("订单号：" + p.ONum);
                                Console.WriteLine("客户名：" + p.OName);
                                //Console.WriteLine("商品名：" + n.Name + " 数量：" + n.Count + " 单价：" + n.Price);
                                for (int j = 0; j < n.oDlist.Count; j++)
                                {
                                    Console.WriteLine("商品名：" + n.oDlist[j].Name + " 数量：" + n.oDlist[j].Count + " 单价：" + n.oDlist[j].Price);
                                }
                            }
                        }
                        
                        


                        //foreach (Order order in olist)
                        //{
                        //    for (int k = 0; k < order.oDlist.Count; k++)
                        //    {
                        //        if (order.oDlist[k].Name == proName)
                        //        {
                        //            Console.WriteLine("订单号：" + order.ONum);
                        //            Console.WriteLine("客户名：" + order.OName);
                        //            for (int j = 0; j < order.oDlist.Count; j++)
                        //            {
                        //                Console.WriteLine("商品名：" + order.oDlist[j].Name + " 数量：" + order.oDlist[j].Count + " 单价：" + order.oDlist[j].Price);
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    break;
                case 4:
                    {
                        var m = from n in olist
                                where n.sumPri > 10000
                                select n;                    
                        foreach (var n in m)
                        {
                            Console.WriteLine("订单号：" + n.ONum);
                            Console.WriteLine("客户名：" + n.OName);
                            for (int j = 0; j < n.oDlist.Count; j++)
                            {
                                Console.WriteLine("商品名：" + n.oDlist[j].Name + " 数量：" + n.oDlist[j].Count + " 单价：" + n.oDlist[j].Price);
                            }
                        }
                                            }
                    break;
            }
        }
    }
}
