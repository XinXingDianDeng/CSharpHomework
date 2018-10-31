using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        
        int i = Form2.ProCount;
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2.Proname[i] = textBox3.Text;
            Form2.Count[i] = Convert.ToInt32(textBox4.Text);
            Form2.Price[i] = Convert.ToDouble(textBox5.Text);
            Close();
        }
    }
}
