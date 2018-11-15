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
        public static string[] Proname ;
        public static int[] Count ;
        public static double[] Price ;
        public static int ProCount { set; get; }
        public OrderService OS;
        public Form2(OrderService order)
        {
            InitializeComponent();
            //textBox3.DataBindings.Add("Text", this, "Key");
            OS = order;
            ProCount = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OS.AddOrder(textBox1.Text, textBox2.Text,textBox4.Text,
               Proname, Count, Price);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
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
                Proname = new string[pcount];
                Count = new int[pcount];
                Price = new double[pcount];
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OS.ReviseOrder(textBox1.Text, Proname, Count, Price);
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
