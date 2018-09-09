using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s = "";
            int a = 0, b = 0;
            s = textBox1.Text.Substring(0);
            a = Int32.Parse(s);
            s = textBox2.Text.Substring(0);
            b = Int32.Parse(s);
            label3.Text = String.Format("{0}", a * b);
        }
    }
}
