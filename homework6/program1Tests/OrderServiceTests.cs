using Microsoft.VisualStudio.TestTools.UnitTesting;
using program2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace program2.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {
            OrderService order = new OrderService();
            Assert.IsNotNull(order);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            List<Order> list1 = new List<Order>();
            Order order1 = new Order(1, "王老板");
            order1.SetOrder("雪碧", 10, 3.5);
            order1.SetOrder("可乐", 15, 4.0);
            order1.SetOrder("鲜橙多", 12, 7.0);
            order1.DCount = 3;
            list1.Add(order1);
            Order order2 = new Order(2, "李先生");
            order2.SetOrder("瓜子", 20, 5.0);
            order2.SetOrder("薯片", 8, 5.5);
            order2.SetOrder("可乐", 12, 3.8);
            order2.DCount = 3;
            list1.Add(order2);
            Order order3 = new Order(3, "小红");
            order3.SetOrder("冰箱", 10, 3999);
            order3.SetOrder("电视", 6, 2999);
            order3.DCount = 2;
            list1.Add(order3);
            //List<Order> list2 = new List<Order>();
            OrderService order = new OrderService();
            string[] proname = { "冰箱", "电视" };
            int[] count = { 10, 6 };
            double[] price = { 3999, 2999 };
            order.AddOrder(3, "小红", proname, count, price);
            Assert.IsTrue(list1 == order.olist);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            List<Order> list1 = new List<Order>();
            Order order1 = new Order(1, "王老板");
            order1.SetOrder("雪碧", 10, 3.5);
            order1.SetOrder("可乐", 15, 4.0);
            order1.SetOrder("鲜橙多", 12, 7.0);
            order1.DCount = 3;
            list1.Add(order1);
            OrderService order = new OrderService();
            order.RemoveOrder(2);
            //bool bo = list1.All(order.olist.Contains) && list1.Count == order.olist.Count;
            Assert.IsTrue(list1 == order.olist);
        }

        [TestMethod()]
        public void ReviseOrderTest()
        {
            List<Order> list1 = new List<Order>();
            Order order1 = new Order(1, "王老板");
            order1.SetOrder("雪碧", 10, 3.5);
            order1.SetOrder("可乐", 15, 4.0);
            order1.SetOrder("鲜橙多", 12, 7.0);
            order1.DCount = 3;
            list1.Add(order1);
            Order order2 = new Order(2, "李先生");
            order2.SetOrder("瓜子", 10, 3.0);
            order2.DCount = 1;
            list1.Add(order2);
            string[] proname = { "瓜子" };
            int[] count = { 10 };
            double[] price = { 3.0 };
            OrderService order = new OrderService();
            order.ReviseOrder(2, proname, count, price);
            Assert.IsTrue(list1 == order.olist);
        }

        [TestMethod()]
        public void FindOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
            doc1.Load(@"..\..\testorder.xml");
            string content1 = doc1.InnerXml;
            OrderService order = new OrderService();
            order.Export("order.xml");
            System.Xml.XmlDocument doc2 = new System.Xml.XmlDocument();
            doc2.Load("order.xml");
            string content2 = doc2.InnerXml;
            Assert.AreEqual(content1,content2);
        }

        [TestMethod()]
        public void ImportTest()
        {
            List<Order> list1 = new List<Order>();
            Order order1 = new Order(1, "王老板");
            order1.SetOrder("雪碧", 10, 3.5);
            order1.SetOrder("可乐", 15, 4.0);
            order1.SetOrder("鲜橙多", 12, 7.0);
            order1.DCount = 3;
            list1.Add(order1);
            Order order2 = new Order(2, "李先生");
            order2.SetOrder("瓜子", 10, 3.0);
            order2.DCount = 1;
            list1.Add(order2);            
            List<Order> list2 = OrderService.Import("order.xml") as List<Order>;

            Assert.IsTrue(list1==list2);
        }
    }
}