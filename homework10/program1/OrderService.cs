using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Data.Entity;

namespace program2
{
    public class OrderService
    {
        public  List<Order> olist = new List<Order>();
        public OrderService()
        {
            

        }

        public void AddOrder(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
                    
                        
        }
        //按订单号删除
        public void RemoveOrder(string onum)
        {
            using(var db = new OrderDB())
            {
                var order = db.Order.Include("oDlist").SingleOrDefault(o => o.ONum == onum);
                db.Order.Remove(order);
                db.OrderDetails.RemoveRange(order.oDlist);
                db.SaveChanges();
            }

        }

        public void ReviseOrder(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.oDlist.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("oDlist").ToList();
            }
        }

        public Order FindOrder(string onum)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("oDlist").SingleOrDefault(o => o.ONum == onum);
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
        //导出为HTML
        public bool ToHtml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\..\Order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"..\..\..\Order.xslt");

                FileStream outFileStream = File.OpenWrite(@"..\..\..\Order.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);
                return true;

            }
            catch (XmlException e)
            {
                Console.WriteLine("XML Exception:" + e.ToString());
                return false;
            }
            catch (XsltException e)
            {
                Console.WriteLine("XSLT Exception:" + e.ToString());
                return false;
            }
        }
    }
}
