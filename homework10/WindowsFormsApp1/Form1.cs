using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using program2;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static OrderService order ;
        public string KeyWord { get; set; }
        List<Order> list = new List<Order>();

        public Form1()
        {
            InitializeComponent();
            order = new OrderService();
            bindingSource1.DataSource = order.GetAllOrders();         
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = order.FindOrder(KeyWord);
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            order.RemoveOrder(KeyWord);
            bindingSource1.DataSource = list;
            bindingSource1.DataSource = order.GetAllOrders();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(order);
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Form2 fm = new Form2(order))
            {
                order = fm.OS;
            }

            bindingSource1.DataSource = list;
            bindingSource1.DataSource = order.GetAllOrders();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(order);
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string pattern1 = "^[0-9]{4}[0-1]{2}[0-3]{2}[0-9]{3}";
            string pattern2 = "^[0-9]{11}";
            int n = 0;
            int m = 0;
            foreach (var num in order.olist)
            {
                
                if (Regex.IsMatch(num.ONum,pattern1))
                    n++;
                if (Regex.IsMatch(num.Tel, pattern2))
                    m++;
            }
            if (n == order.olist.Count)
            {
                label1.Text = "订单号无问题";
            }
            else
            {
                label1.Text = "订单号有问题";
            }
            if (m == order.olist.Count)
            {
                label2.Text = "电话号码无问题";
            }
            else
            {
                label2.Text = "电话号码有问题";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
