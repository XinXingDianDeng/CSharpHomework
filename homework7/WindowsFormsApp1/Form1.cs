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
    public partial class Form1 : Form
    {
        public static OrderService order = new OrderService();
        public string KeyWord { get; set; }
        List<Order> list = new List<Order>();

        public Form1()
        {
            InitializeComponent();
            
            bindingSource1.DataSource = order.olist;           
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
            bindingSource1.DataSource = order.olist.Where(
                s => s.OName == KeyWord||s.ONum == Convert.ToInt32(KeyWord));
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            order.RemoveOrder(Convert.ToInt32(KeyWord));
            bindingSource1.DataSource = list;
            bindingSource1.DataSource = order.olist;
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
            bindingSource1.DataSource = order.olist;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(order);
            form2.Show();
        }
    }
}
