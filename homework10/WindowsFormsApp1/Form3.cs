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
    public partial class Form3 : Form
    {
        
        int i = Form2.ProCount;
        //public List<OrderDetails> orderDetails;
        public Form3(List<OrderDetails> details)
        {
            InitializeComponent();
            //orderDetails = details;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OrderDetails Orderdetails = new OrderDetails(textBox1.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToDouble(textBox5.Text));
            //orderDetails.Add(details);
            Form2.details.Add(Orderdetails);
            
      
            
            Close();
        }
    }
}
