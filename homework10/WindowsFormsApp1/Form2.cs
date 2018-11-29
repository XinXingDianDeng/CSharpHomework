using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program2;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        //public static string Key { get; set; }
        //static int pcount = Convert.ToInt32(Key);
        static int pcount;
        public static int ProCount { set; get; }
        public static List<OrderDetails> details ;

        public OrderService OS = new OrderService();
        public Form2(OrderService orderservice)
        {
            InitializeComponent();
            details = new List<OrderDetails>();
            //OS = orderservice;
            ProCount = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order(textBox1.Text, textBox2.Text, textBox4.Text, details);
            OS.AddOrder(order);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(details);
            form3.Show();            
            ProCount++;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //using (Form1 fm = new Form1())
            //{
               
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pcount = Convert.ToInt32(textBox3.Text);
                
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //OS.ReviseOrder();
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
