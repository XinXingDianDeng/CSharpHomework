using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace program2
{
    public class OrderService
    {
        public  List<Order> olist = new List<Order>();
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

        public bool AddOrder(int onum, string oname,
            string[] proName,int[] count,double[] price)
        {
            Order order = new Order(onum, oname);
            olist.Add(order);
            for(int i = 0;i < proName.Length;i++)
            {
                order.SetOrder(proName[i], count[i], price[i]);
                order.DCount += 1;
            }           
            
            return true;
        }
        //按订单号删除
        public void RemoveOrder(int onum)
        {
            for (int m = 0;m < olist.Count;m ++)
            {

                try
                {
                    if (olist[m].ONum == onum)
                    {
                        olist.Remove(olist[m]);
                    
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("错误");
                }

            }

        }

        public void ReviseOrder(int num,string[] proName, int[] count, double[] price)
        {
            //Console.Write("请输入要修改的订单号：");
            //int onum = Int32.Parse(Console.ReadLine());
            string oname;
            for (int m = 0; m < olist.Count; m++)
            {
                try
                {
                    if (olist[m].ONum == num)
                    {
                        oname = olist[m].OName;                        
                        RemoveOrder(num);
                        AddOrder(num, oname,proName,count,price);
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
                                              
                    }
                    break;
                case 3:
                    {
                        Console.Write("请输入要查询的商品名：");
                        string proName = Console.ReadLine();

                        foreach (var p in olist)
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
        //序列化
        public bool Export(string filename)
        {
            try
            {
                StreamWriter writer
                    = new StreamWriter(filename, false, Encoding.GetEncoding("utf-8"));
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                xmlser.Serialize(writer, olist);
                writer.Close();                
                Console.WriteLine("XML序列化成功");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
        //反序列化
        public static object Import(string filename)
        {
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {                   
                    object obj = xmlser.Deserialize(fs);
                    Console.WriteLine("反序列化成功");
                    return obj;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
