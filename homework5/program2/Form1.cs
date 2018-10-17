using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        
        static int ang1;
        static int ang2;
        double th1 = ang1 * Math.PI / 180;
        double th2 = ang2 * Math.PI / 180;
        double per1 = 0.5;
        double per2 = 0.7;
        double k;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            double x3 = x0 + leng * k * Math.Cos(th);
            double y3 = y0 + leng * k * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1 );
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2 );
            //drawCayleyTree(n - 1, x3, y3, per2 * leng, th + th2);

        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(
                Pens.Green,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                k = Double.Parse(textBox1.Text);
            }
            catch { }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ang2 = Int32.Parse(textBox3.Text);
                th2 = ang2 * Math.PI / 180;
            }
            catch
            {
                
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ang1 = Int32.Parse(textBox2.Text);
                th1 = ang1 * Math.PI / 180;
            }
            catch
            {
                
            }
        }
    }
}
